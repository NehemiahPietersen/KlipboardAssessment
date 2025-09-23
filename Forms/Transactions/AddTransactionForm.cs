using CustomerManager.Data.Entities;
using KlipBoardAssessment.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlipBoardAssessment.Forms.Transactions
{
    public partial class AddTransactionForm : Form
    {
        private UnitOfWork _unitOfWork;

        public AddTransactionForm(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            txtAmount.KeyPress += TxtAmount_KeyPress;

            // Enter key to save
            this.AcceptButton = btnSave;
            // Escape key to cancel
            this.CancelButton = btnCancel;
        }

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            SetDefaultValues();
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _unitOfWork.Customers.GetAll()
                    .OrderBy(c => c.CustomerName)
                    .ToList();

                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "CustomerName";
                cmbCustomer.ValueMember = "Account";

                if (customers.Any())
                {
                    cmbCustomer.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultValues()
        {
            // Set default date to today
            dtpTransactionDate.Value = DateTime.Now;

            // Set default transaction type to Debit
            rdbDebit.Checked = true;

            // Set focus to amount field
            txtAmount.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveTransaction();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            // Validate Customer selection
            if (cmbCustomer.SelectedItem == null)
            {
                ShowValidationError("Please select a customer.", cmbCustomer);
                return false;
            }

            // Validate Amount
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                ShowValidationError("Please enter an amount.", txtAmount);
                return false;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                ShowValidationError("Please enter a valid positive amount.", txtAmount);
                return false;
            }

            if (amount > 1000000) // Reasonable limit
            {
                ShowValidationError("Amount cannot exceed 1,000,000.", txtAmount);
                return false;
            }

            // Validate Transaction Type
            if (!rdbDebit.Checked && !rdbCredit.Checked)
            {
                ShowValidationError("Please select a transaction type.", pnlTransactionType);
                return false;
            }

            // Validate Date (not in future)
            if (dtpTransactionDate.Value > DateTime.Now)
            {
                ShowValidationError("Transaction date cannot be in the future.", dtpTransactionDate);
                return false;
            }

            return true;
        }

        private void SaveTransaction()
        {
            try
            {
                var selectedCustomer = (Customer)cmbCustomer.SelectedItem;
                var amount = decimal.Parse(txtAmount.Text);
                var transactionType = rdbDebit.Checked ? 'D' : 'C';

                // Update customer balance
                if (transactionType == 'D')
                {
                    selectedCustomer.Balance += amount;
                }
                else // Credit
                {
                    selectedCustomer.Balance -= amount;
                }

                // Create transaction
                var transaction = new Transaction
                {
                    Account = selectedCustomer.Account,
                    Amount = transactionType == 'D' ? amount : -amount, 
                    TransactionType = transactionType,
                    CreatedAt = dtpTransactionDate.Value,
         
                };

                //save to database
                _unitOfWork.Transactions.Add(transaction);
                _unitOfWork.Complete();

                MessageBox.Show("Transaction saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving transaction: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();

            if (control is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, decimal point, and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
            {
                e.Handled = true;
                return;
            }

            // Allow Enter key to trigger save
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSave.PerformClick();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

    }
}
