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

namespace CustomerManager.Forms
{
    public partial class AddCustomer : Form
    {
        private UnitOfWork _unitOfWork;

        public AddCustomer(UnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            customerNameTxtBox.MaxLength = 50;
            customerAccTxtBox.MaxLength = 15;

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string customerName = customerNameTxtBox.Text.Trim();
            string customerAccount = customerAccTxtBox.Text.Trim();


            //Validate user input
            if (string.IsNullOrWhiteSpace(customerName))
            {
                MessageBox.Show("Customer name is required.");
                return;
            }

            if (customerName.Length > 50)
            {
                MessageBox.Show("Customer name cannot exceed 50 characters.");
                return;
            }

            if (string.IsNullOrWhiteSpace(customerAccount))
            {
                MessageBox.Show("Customer account is required.");
                return;
            }

            if (customerAccount.Length > 15)
            {
                MessageBox.Show("Customer account cannot exceed 15 characters.");
                return;
            }

            var customer = new Customer
            {
                CustomerName = customerName,
                Account = customerAccount
            };

            try
            {
                _unitOfWork.Customers.Add(customer);
                _unitOfWork.SaveChanges();

                MessageBox.Show("Customer added successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}");
            }
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
