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

namespace CustomerManager.Forms.Enquiries
{
    public partial class EnquiresPortal : Form
    {
        private Customer _customer;
        private Transaction _transaction;
        private Label lblNameValue;
        private Label lblAccountValue;
        private Label lblBalanceValue;
        private Label lblDateValue;
        private DataGridView transactionGrid;

        public EnquiresPortal(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            InitializeUI();
        }

        public EnquiresPortal(Transaction transaction)
        {
            InitializeUI();
            _transaction = transaction;
            _customer = transaction.Customer;
        }


        private void EnquiresPortal_Load(object sender, EventArgs e)
        {
            Text = $"Enquiry - {_customer.CustomerName}";
            lblNameValue.Text = _customer.CustomerName;
            lblAccountValue.Text = _customer.Account;
            lblBalanceValue.Text = _customer.Balance.ToString("C");
            lblDateValue.Text = _customer.CreatedAt.ToShortDateString();

            LoadTransactionGrid();
        }

        private void LoadTransactionGrid()
        {
            using (var context = new ApplicationDbContext())
            {
                var transactions = context.Transactions
                    .Where(t => t.Account == _customer.Account)
                    .OrderByDescending(t => t.CreatedAt)
                    .ToList();

                transactionGrid.DataSource = transactions;
            }
        }

        private void InitializeUI()
        {
            this.Text = "Enquiry Portal";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += EnquiresPortal_Load;

            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 300
            };

            this.Controls.Add(splitContainer);

            //left panel
            var leftPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 8,
                ColumnCount = 2,
                Padding = new Padding(10),
                AutoSize = true
            };
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));

            //Labels
            leftPanel.Controls.Add(new Label { Text = "Customer Name:", AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) }, 0, 0);
            lblNameValue = new Label { AutoSize = true, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblNameValue, 1, 0);

            leftPanel.Controls.Add(new Label { Text = "Customer Account:", AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) }, 0, 1);
            lblAccountValue = new Label { AutoSize = true, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblAccountValue, 1, 1);

            leftPanel.Controls.Add(new Label { Text = "Customer Balance:", AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) }, 0, 2);
            lblBalanceValue = new Label { AutoSize = true, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblBalanceValue, 1, 2);

            leftPanel.Controls.Add(new Label { Text = "Date Registered:", AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) }, 0, 3);
            lblDateValue = new Label { AutoSize = true, Font = new Font("Segoe UI", 10) };
            leftPanel.Controls.Add(lblDateValue, 1, 3);

            var leftContainer = new Panel
            {
                Dock = DockStyle.Fill
            };
            leftPanel.Dock = DockStyle.Top;
            leftContainer.Controls.Add(leftPanel);

            //Go back button
            var GoBackBtn = new Button
            {
                Text = "← Go Back",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                AutoSize = true,
                Padding = new Padding(6),
                Margin = new Padding(10),
                Dock = DockStyle.Bottom
            };
            GoBackBtn.Click += (s, e) => this.Close();

            leftContainer.Controls.Add(GoBackBtn);

            splitContainer.Panel1.Controls.Add(leftContainer);

            transactionGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };

            splitContainer.Panel2.Controls.Add(transactionGrid);
        }
    
    }
}
