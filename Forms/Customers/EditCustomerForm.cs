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
    public partial class EditCustomerForm : Form
    {
        private UnitOfWork _unitOfWork;
        private int _customerId;
        private Customer _customer;

        public EditCustomerForm(UnitOfWork unitOfWork, int customerId)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _customerId = customerId;
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            txtName.KeyPress += Txt_KeyPress;

            //enter key to save
            this.AcceptButton = btnSave;
            //escape key to cancel
            this.CancelButton = btnCancel;
        }

        private void EditCustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            try
            {
                _customer = _unitOfWork.Customers.GetById(_customerId);

                if (_customer == null)
                {
                    MessageBox.Show("Customer not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Populate form fields
                txtName.Text = _customer.CustomerName;
                txtAccount.Text = _customer.Account;
                lblBalanceValue.Text = _customer.Balance.ToString("C2");
                lblCreatedAtValue.Text = _customer.CreatedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm");

                // Style balance based on amount
                if (_customer.Balance < 0)
                {
                    lblBalanceValue.ForeColor = Color.Red;
                }
                else if (_customer.Balance > 0)
                {
                    lblBalanceValue.ForeColor = Color.Green;
                }
                else
                {
                    lblBalanceValue.ForeColor = SystemColors.ControlText;
                }

                // Set focus to name field and select all text
                txtName.Focus();
                txtName.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput() && SaveCustomer())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            string newName = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName))
            {
                ShowValidationError("Customer name is required.", txtName);
                return false;
            }

            if (newName.Length > 50)
            {
                ShowValidationError("Customer name cannot exceed 50 characters.", txtName);
                return false;
            }

            // Check if name is actually changed
            if (newName == _customer.CustomerName)
            {
                MessageBox.Show("No changes were made.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private bool SaveCustomer()
        {
            try
            {
                //update customer properties
                _customer.CustomerName = txtName.Text.Trim();

                _unitOfWork.Complete();

                MessageBox.Show("Customer updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow Enter key to trigger save
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSave.PerformClick();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Clean up resources if needed
            base.OnFormClosing(e);
        }
    }
}
