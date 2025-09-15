using CustomerManager.Data;
using CustomerManager.Data.Entities;
using CustomerManager.Forms;
using CustomerManager.Forms.Enquiries;
using CustomerManager.Forms.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Principal;
using System.Windows.Forms;

namespace CustomerManager
{
    public partial class MainForm : Form
    {
        private UnitOfWork _unitOfWork;
        private string _currentTable;
        private Button _btnAddCustomer; 
        private Button _btnEditCustomer; 
        private Button _btnAddTransaction; 
        private Button _btnEditTransaction; 
        private DataGridView dataGridView; 
        private Button customerBtn;
        private Button transactionBtn;
        private string _selectedSort = "Name";
        private ComboBox _customerSortComboBox;
        private ComboBox _transactionSortComboBox;
        private string _selectedTransactionSort = "Date Added";

        public MainForm()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
            InitializeUI();
        }

        private void InitializeUI()
        {
            //Initialize UI components and event handlers here

            //CustomerButtons
            customerBtn = new Button
            {
                Text = "Customers",
                Dock = DockStyle.Top,
                Name = "customerBtn"
            };
            customerBtn.Click += CustomerBtn_Click;

            _btnAddCustomer = new Button
            {
                Text = "Add Customer",
                Visible = false,
                Dock = DockStyle.Top,
                Name = "btnAddCustomer"
            };
            _btnAddCustomer.Click += AddCustomersBtn_Click;
            splitContainer1.Panel2.Controls.Add(_btnAddCustomer);

            _btnEditCustomer = new Button
            {
                Text = "Edit Customer",
                Visible = false,
                Dock = DockStyle.Top,
                Name = "btnEditCustomer"
            };
            _btnEditCustomer.Click += EditCustomerBtn_Click;
            splitContainer1.Panel2.Controls.Add(_btnEditCustomer);

            //TransactionButtons
            transactionBtn = new Button
            {
                Text = "Transactions",
                Dock = DockStyle.Top,
                Name = "transactionBtn"
            };
            transactionBtn.Click += TransactionBtn_Click;

            _btnAddTransaction = new Button
            {
                Text = "Add Transaction",
                Visible = false,
                Dock = DockStyle.Top,
                Name = "btnAddTransaction"
            };
            _btnAddTransaction.Click += AddTransactionButton_Click;
            splitContainer1.Panel2.Controls.Add(_btnAddTransaction);

            _btnEditTransaction = new Button
            {
                Text = "Edit Transaction",
                Visible = false,
                Dock = DockStyle.Top,
                Name = "btnEditTransaction"
            };
            _btnEditTransaction.Click += EditTransactionBtn_Click;
            splitContainer1.Panel2.Controls.Add(_btnEditTransaction);

            //DataGridView
            Panel dataGridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 80, 0, 0),
                Name = "dataGridPanel"
            };

            //Create the DataGridView
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                Name = "dataGridView"
            };
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            dataGridView.CellContentClick += DataGridView_CellContentClick;

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dataGridView.Columns.Add(deleteColumn);

            //Add the DataGridView to the padded panel
            dataGridPanel.Controls.Add(dataGridView);
            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;

            //Add the panel to the SplitContainer's Panel2
            splitContainer1.Panel2.Controls.Add(dataGridPanel);

            ApplyTabStyle(customerBtn);
            ApplyTabStyle(transactionBtn);

            //Sorting
            _customerSortComboBox = new ComboBox
            {
                Name = "customerSortComboBox",
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _customerSortComboBox.Items.AddRange(new[] { "Name", "Account", "Date Added" });
            _customerSortComboBox.SelectedIndexChanged += CustomerSortComboBox_SelectedIndexChanged;

            _transactionSortComboBox = new ComboBox
            {
                Name = "transactionSortComboBox",
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Visible = false // Start hidden
            };
            _transactionSortComboBox.Items.AddRange(new[] { "Account", "Name", "Outstanding Amount", "Date Added" });
            _transactionSortComboBox.SelectedIndexChanged += TransactionSortComboBox_SelectedIndexChanged;

            splitContainer1.Panel1.Controls.Add(transactionBtn);
            splitContainer1.Panel1.Controls.Add(customerBtn);

            dataGridPanel.Controls.Add(dataGridView);
            splitContainer1.Panel2.Controls.Add(dataGridPanel);
            splitContainer1.Panel2.Controls.Add(_transactionSortComboBox);
            splitContainer1.Panel2.Controls.Add(_customerSortComboBox);
            splitContainer1.Panel2.Controls.SetChildIndex(_transactionSortComboBox, 0);
            splitContainer1.Panel2.Controls.SetChildIndex(_customerSortComboBox, 0);

            dataGridView.DataSource = LoadCustomers();

            CustomerBtn_Click(null, EventArgs.Empty);
        }

        //CUSTOMERS
        private void CustomerBtn_Click(object sender, EventArgs e)
        {
            SelectTab(customerBtn);
            ShowCustomerButtons();

            _customerSortComboBox.Visible = true;
            _transactionSortComboBox.Visible = false;

            dataGridView.DataSource = LoadCustomers(_selectedSort);
        }

        private void AddCustomersBtn_Click(object sender, EventArgs e)
        {
            using (var addCustomerForm = new AddCustomer(_unitOfWork))
            {
                var result = addCustomerForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    dataGridView.DataSource = LoadCustomers(_selectedSort);
                }
            }
        }

        private void EditCustomerBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer to edit.");
                return;
            }

            int customerId = (int)dataGridView.CurrentRow.Cells["CustomerId"].Value;


            using (var editForm = new EditCustomer(_unitOfWork, customerId))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    dataGridView.DataSource = LoadCustomers(_selectedSort);
                }
            }
        }

        public List<Customer> LoadCustomers(string sortBy = "Name")
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Customer> query = context.Customers;

                switch (sortBy)
                {
                    case "Account":
                        query = query.OrderBy(c => c.Account);
                        break;
                    case "Date Added":
                        query = query.OrderBy(c => c.CreatedAt); // Make sure you have CreatedAt
                        break;
                    default:
                        query = query.OrderBy(c => c.CustomerName);
                        break;
                }

                var customers = query.ToList();

                dataGridView.DataSource = customers;

                if (!dataGridView.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true,
                        Width = 70,
                        FlatStyle = FlatStyle.Flat
                    };
                    dataGridView.Columns.Add(deleteColumn);
                }

                return customers;
            }
        }

        //TRANSACTIONS
        private void TransactionBtn_Click(object sender, EventArgs e)
        {
            SelectTab(transactionBtn);
            ShowTransactionButtons();

            _customerSortComboBox.Visible = false;
            _transactionSortComboBox.Visible = true;

            dataGridView.DataSource = LoadTransactions(_selectedTransactionSort);
        }

        private void AddTransactionButton_Click(object sender, EventArgs e)
        {
            using (var addTransactionForm = new AddTransaction(_unitOfWork))
            {
                if (addTransactionForm.ShowDialog() == DialogResult.OK)
                {
                    dataGridView.DataSource = LoadTransactions();
                }
            }
        }

        private void EditTransactionBtn_Click(object sender, EventArgs e)
        {
            //Check if a row is selected
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a transaction to edit.");
                return;
            }

            using (var editTransactionForm = new EditTransaction())
            {
                if (editTransactionForm.ShowDialog() == DialogResult.OK)
                {
                    //Refresh data after editing transaction
                    dataGridView.DataSource = LoadTransactions();
                    MessageBox.Show("Transaction updated successfully!");
                }
            }
        }

        public List<Transaction> LoadTransactions(string sortBy = "Date Added")
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Transaction> query = context.Transactions.Include(t => t.Customer); // assuming navigation property

                switch (sortBy)
                {
                    case "Account":
                        query = query.OrderBy(t => t.Customer.Account);
                        break;
                    case "Name":
                        query = query.OrderBy(t => t.Customer.CustomerName);
                        break;
                    case "Outstanding Amount":
                        query = query.OrderByDescending(t => t.Customer.Balance);
                        break;
                    case "Date Added":
                        query = query.OrderByDescending(t => t.CreatedAt);
                        break;
                    default:
                        query = query.OrderByDescending(t => t.CreatedAt);
                        break;
                }

                return query.ToList();
            }

        }

        //HELPER METHODS
        private void SelectTab(Button selectedButton)
        {
            foreach (Control ctrl in splitContainer1.Panel1.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = Color.Black;
                    btn.Font = new Font(btn.Font, FontStyle.Regular);
                }
            }

            selectedButton.BackColor = Color.LightSteelBlue;
            selectedButton.ForeColor = Color.Black;
            selectedButton.Font = new Font(selectedButton.Font, FontStyle.Bold);
        }

        private void ApplyTabStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Dock = DockStyle.Top;
            btn.Height = 40;
            btn.FlatAppearance.BorderSize = 0;
            btn.Margin = new Padding(0);
        }

        private void TableList_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var listBox = (ListBox)sender;

            if (listBox.SelectedItem == null)
                return;

            _currentTable = listBox.SelectedItem.ToString();

            switch (_currentTable)
            {
                case "Customers":
                    LoadCustomers();
                    break;
                case "Transactions":
                    LoadTransactions();
                    break;
            }
        }
        private void ShowCustomerButtons()
        {
            _btnAddCustomer.Visible = true;
            _btnEditCustomer.Visible = true;

            _btnAddTransaction.Visible = false;
            _btnEditTransaction.Visible = false;
        }

        private void ShowTransactionButtons()
        {
            _btnAddCustomer.Visible = false;
            _btnEditCustomer.Visible = false;

            _btnAddTransaction.Visible = true;
            _btnEditTransaction.Visible = true;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                var customerId = (int)dataGridView.Rows[e.RowIndex].Cells["CustomerId"].Value;
                var customerName = dataGridView.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();

                var confirm = MessageBox.Show(
                    $"Are you sure you want to delete '{customerName}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var customer = _unitOfWork.Customers.GetById(customerId);
                        if (customer != null)
                        {
                            _unitOfWork.Customers.Delete(customer);
                            _unitOfWork.SaveChanges();

                            MessageBox.Show("Customer deleted successfully.");

                            CustomerBtn_Click(null, EventArgs.Empty);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}");
                    }
                }
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font(dataGridView.Font, FontStyle.Bold);
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void DataGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView.Columns[e.ColumnIndex].Name == "Delete")
                return;

            if (_currentTable == "Customers" || customerBtn.BackColor == Color.LightSteelBlue)
            {
                int customerId = (int)dataGridView.Rows[e.RowIndex].Cells["CustomerId"].Value;
                OpenEnquiriesPortal(customerId, isCustomer: true);
            }
            else if (_currentTable == "Transactions" || transactionBtn.BackColor == Color.LightSteelBlue)
            {
                int transactionId = (int)dataGridView.Rows[e.RowIndex].Cells["TransactionId"].Value;
                OpenEnquiriesPortal(transactionId, isCustomer: false);
            }
        }

        private void OpenEnquiriesPortal(int id, bool isCustomer)
        {
            using (var context = new ApplicationDbContext())
            {
                if (isCustomer)
                {
                    var customer = context.Customers.FirstOrDefault(c => c.CustomerId == id);
                    if (customer != null)
                    {
                        var portal = new EnquiresPortal(customer);
                        portal.ShowDialog();
                    }
                }
                else
                {
                    var transaction = context.Transactions
                                             .Include(t => t.Customer)
                                             .FirstOrDefault(t => t.TransactionId == id);
                    if (transaction != null)
                    {
                        var portal = new EnquiresPortal(transaction);
                        portal.ShowDialog();
                    }
                }
            }
        }

        private void SortComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            _selectedSort = comboBox.SelectedItem?.ToString() ?? "Name";
            dataGridView.DataSource = LoadCustomers(_selectedSort);
        }

        private void CustomerSortComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            _selectedSort = _customerSortComboBox.SelectedItem?.ToString() ?? "Name";
            dataGridView.DataSource = LoadCustomers(_selectedSort);
        }

        private void TransactionSortComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            _selectedTransactionSort = _transactionSortComboBox.SelectedItem?.ToString() ?? "Date Added";
            dataGridView.DataSource = LoadTransactions(_selectedTransactionSort);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
