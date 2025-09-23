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

namespace KlipBoardAssessment.Forms.Customers
{
    public partial class AddCustomerForm : Form
    {
        private readonly UnitOfWork _unitOfWork;

        public AddCustomerForm(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            txtName.KeyPress += Txt_KeyPress;
            txtAccount.KeyPress += Txt_KeyPress;

            //enter key to save
            this.AcceptButton = btnSave;
            //escape key to cancel
            this.CancelButton = btnCancel;
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            txtName.MaxLength = 50;
            txtAccount.MaxLength = 15;

            //set focus to name field
            txtName.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveCustomer();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            string customerName = txtName.Text.Trim();
            string customerAccount = txtAccount.Text.Trim();

            // Validate Name
            if (string.IsNullOrWhiteSpace(customerName))
            {
                ShowValidationError("Please enter a customer name.", txtName);
                return false;
            }

            if (customerName.Length > 50)
            {
                ShowValidationError("Customer name cannot exceed 50 characters.", txtName);
                return false;
            }

            // Validate Account
            if (string.IsNullOrWhiteSpace(customerAccount))
            {
                ShowValidationError("Please enter an account number.", txtAccount);
                return false;
            }

            if (customerAccount.Length > 15)
            {
                ShowValidationError("Account number cannot exceed 15 characters.", txtAccount);
                return false;
            }

            // Check if account already exists
            if (AccountExists(customerAccount))
            {
                ShowValidationError("An account with this number already exists.", txtAccount);
                return false;
            }

            return true;
        }

        private bool AccountExists(string accountNumber)
        {
            try
            {
                var existingCustomer = _unitOfWork.Customers.Find(c => c.Account == accountNumber).FirstOrDefault();
                return existingCustomer != null;
            }
            catch
            {
                return false;
            }
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

            control.Focus();

            if (control is TextBoxBase textBox)
            {
                textBox.SelectAll();
            }
            else if (control is ComboBox comboBox && comboBox.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                comboBox.SelectAll();

            }
        }

        private void SaveCustomer()
        {
            try
            {
                var customer = new Customer
                {
                    CustomerName = txtName.Text.Trim(),
                    Account = txtAccount.Text.Trim(),
                    Balance = 0,
                    CreatedAt = DateTime.UtcNow
                };

                _unitOfWork.Customers.Add(customer);
                _unitOfWork.Complete();

                MessageBox.Show("Customer added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow Enter key to trigger save
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSave.PerformClick();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //clean up resources if needed
            base.OnFormClosing(e);
        }

    }
}
