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
    public partial class EditCustomer : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int _customerId;
        private Customer _customer;

        public EditCustomer(UnitOfWork unitOfWork, int customerId)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _customerId = customerId;
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            _customer = _unitOfWork.Customers.GetById(_customerId);

            if (_customer == null)
            {
                MessageBox.Show("Sorry. Customer not found.");
                this.Close();
                return;
            }

            customerNameTxtBox.Text = _customer.CustomerName;
            customerAccTxtBox.Text = _customer.Account;

            customerAccTxtBox.ReadOnly = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string newName = customerNameTxtBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName) || newName.Length > 50)
            {
                MessageBox.Show("Customer name is required and must be 50 characters or fewer.");
                return;
            }

            _customer.CustomerName = newName;
            _unitOfWork.SaveChanges();

            MessageBox.Show("Customer updated successfully.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void customerAccTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
