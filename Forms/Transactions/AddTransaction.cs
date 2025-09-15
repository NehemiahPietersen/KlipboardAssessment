using CustomerManager.Data;
using CustomerManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManager.Forms.Transactions
{
    public partial class AddTransaction : Form
    {

        private readonly UnitOfWork _unitOfWork;
        private ComboBox CustomerComboBox;

        public AddTransaction(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;

            CustomerComboBox = new ComboBox();
            CustomerComboBox.Name = "CustomerComboBox";
            CustomerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CustomerComboBox.Width = 200;
            CustomerComboBox.Location = new Point(32, 42);
            Controls.Add(CustomerComboBox);

            this.Load += AddTransaction_Load;
        }

        private void AddTransaction_Load(object sender, EventArgs e)
        {
            var customers = _unitOfWork.Customers.GetAll().ToList();

            CustomerComboBox.DataSource = customers;
            CustomerComboBox.DisplayMember = "CustomerName";
            CustomerComboBox.ValueMember = "Account";
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SaveTransactioinBtn_Click(object sender, EventArgs e)
        {
            if (CustomerComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            if (!decimal.TryParse(TransactionAmountTxtBox.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount.");
                return;
            }

            if (!DebitRadioBtn.Checked && !CreditRadioBtn.Checked)
            {
                MessageBox.Show("Please select a transaction type.");
                return;
            }

            char transactionType = DebitRadioBtn.Checked ? 'D' : 'C';
            string account = CustomerComboBox.SelectedValue.ToString();

            var customer = _unitOfWork.Customers.GetCustomerByAccount(account);
            if (customer == null)
            {
                MessageBox.Show("Selected customer not found.");
                return;
            }

            if (transactionType == 'D')
            {
                customer.Balance += amount;
            }
            else if (transactionType == 'C')
            {
                customer.Balance -= amount;
            }

            var transaction = new Transaction
            {
                Account = account,
                Amount = amount,
                TransactionType = transactionType,
                CreatedAt = TransactionDatePicker.Value
            };

            try
            {
                _unitOfWork.Transactions.Add(transaction);
                _unitOfWork.Customers.Update(customer);
                _unitOfWork.SaveChanges();

                MessageBox.Show("Transaction saved and balance updated.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving transaction: " + ex.Message);
            }
        }
    }
}
