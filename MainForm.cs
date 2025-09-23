using CustomerManager.Data.Entities;
using KlipBoardAssessment.Data;
using KlipBoardAssessment.Data.Repositories.Interface;
using KlipBoardAssessment.Forms.Customers;
using KlipBoardAssessment.Forms.Transactions;
using KlipBoardAssessment.Services;
using System.ComponentModel;
using System.Windows.Forms;

namespace KlipBoardAssessment
{
    public partial class MainForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly BindingList<Customer> _customersBindingList;
        private readonly BindingList<Transaction> _transactionsBindingList;
        private ViewMode _currentViewMode;

        private enum ViewMode
        {
            Customers,
            Transactions
        }

        public MainForm()
        {
            InitializeComponent();

            //initialize database
            var context = new ApplicationDbContext();
            var initializer = new DatabaseInitializer(context);
            initializer.Initialize();

            _unitOfWork = new UnitOfWork(context);
            _customersBindingList = new BindingList<Customer>();
            _transactionsBindingList = new BindingList<Transaction>();

            InitializeUI();
            SwitchToView(ViewMode.Customers);
        }

        private void InitializeUI()
        {
            SetupDataGridView();
            SetupEventHandlers();
            ApplyInitialStyling();

            // Ensure buttons are properly positioned and visible
            PositionHeaderControls();
        }

        private void SetupDataGridView()
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Common columns setup
            dataGridView.CellFormatting += DataGridView_CellFormatting;
            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
            dataGridView.CellContentClick += DataGridView_CellContentClick;
        }

        private void PositionHeaderControls()
        {
            btnAdd.Location = new Point(10, 8);
            btnEdit.Location = new Point(110, 8);
            cmbSort.Location = new Point(pnlHeader.Width - cmbSort.Width - 10, 8);

            pnlHeader.Height = 50;

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            cmbSort.Visible = true;
        }


        private void SetupEventHandlers()
        {
            btnCustomers.Click += (s, e) => SwitchToView(ViewMode.Customers);
            btnTransactions.Click += (s, e) => SwitchToView(ViewMode.Transactions);
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            cmbSort.SelectedIndexChanged += CmbSort_SelectedIndexChanged;
        }

        private void ApplyInitialStyling()
        {
            // Apply styling to navigation buttons
            foreach (Control ctrl in pnlNavigation.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Padding = new Padding(10, 0, 0, 0);
                    btn.Height = 40;
                }
            }
        }

        private void SwitchToView(ViewMode mode)
        {
            _currentViewMode = mode;
            UpdateNavigationHighlight();
            UpdateButtonVisibility();
            LoadData();
            UpdateSortComboBox();
        }

        private void UpdateNavigationHighlight()
        {
            btnCustomers.BackColor = _currentViewMode == ViewMode.Customers ?
                Color.LightSteelBlue : SystemColors.Control;
            btnTransactions.BackColor = _currentViewMode == ViewMode.Transactions ?
                Color.LightSteelBlue : SystemColors.Control;

            btnCustomers.Font = new Font(btnCustomers.Font,
                _currentViewMode == ViewMode.Customers ? FontStyle.Bold : FontStyle.Regular);
            btnTransactions.Font = new Font(btnTransactions.Font,
                _currentViewMode == ViewMode.Transactions ? FontStyle.Bold : FontStyle.Regular);
        }

        private void UpdateButtonVisibility()
        {
            btnAdd.Visible = true;
            btnEdit.Visible = true;

            btnAdd.Text = _currentViewMode == ViewMode.Customers ?
                "Add Customer" : "Add Transaction";
            btnEdit.Text = _currentViewMode == ViewMode.Customers ?
                "Edit Customer" : "Edit Transaction";
        }

        private void UpdateSortComboBox()
        {
            cmbSort.Items.Clear();

            if (_currentViewMode == ViewMode.Customers)
            {
                cmbSort.Items.AddRange(new[] { "Name", "Account", "Date Added" });
                cmbSort.SelectedItem = "Name";
            }
            else
            {
                cmbSort.Items.AddRange(new[] { "Date Added", "Account", "Name", "Amount" });
                cmbSort.SelectedItem = "Date Added";
            }
        }

        private void LoadData()
        {
            try
            {
                if (_currentViewMode == ViewMode.Customers)
                {
                    LoadCustomers();
                }
                else
                {
                    LoadTransactions();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            var sortBy = cmbSort.SelectedItem?.ToString() ?? "Name";
            var customers = GetCustomersSorted(sortBy);

            _customersBindingList.Clear();
            foreach (var customer in customers)
            {
                _customersBindingList.Add(customer);
            }

            dataGridView.DataSource = _customersBindingList;
            ConfigureCustomerColumns();
        }

        private void LoadTransactions()
        {
            var sortBy = cmbSort.SelectedItem?.ToString() ?? "Date Added";
            var transactions = GetTransactionsSorted(sortBy);

            _transactionsBindingList.Clear();
            foreach (var transaction in transactions)
            {
                _transactionsBindingList.Add(transaction);
            }

            dataGridView.DataSource = _transactionsBindingList;
            ConfigureTransactionColumns();
        }

        private List<Customer> GetCustomersSorted(string sortBy)
        {
            return sortBy switch
            {
                "Account" => _unitOfWork.Customers.GetAll()
                    .OrderBy(c => c.Account).ToList(),
                "Date Added" => _unitOfWork.Customers.GetAll()
                    .OrderByDescending(c => c.CreatedAt).ToList(),
                _ => _unitOfWork.Customers.GetAll()
                    .OrderBy(c => c.CustomerName).ToList()
            };
        }

        private List<Transaction> GetTransactionsSorted(string sortBy)
        {
            var transactions = _unitOfWork.Transactions.GetAllWithCustomers();

            return sortBy switch
            {
                "Account" => transactions.OrderBy(t => t.Account).ToList(),
                "Name" => transactions.OrderBy(t => t.Customer.CustomerName).ToList(),
                "Amount" => transactions.OrderByDescending(t => t.Amount).ToList(),
                _ => transactions.OrderByDescending(t => t.CreatedAt).ToList()
            };
        }

        private void ConfigureCustomerColumns()
        {
            dataGridView.Columns.Clear();

            AddColumn("CustomerId", "ID", 50);
            AddColumn("CustomerName", "Name", 150);
            AddColumn("Account", "Account", 100);
            AddColumn("CreatedAt", "Created", 80);

            AddDeleteButtonColumn();
        }

        private void ConfigureTransactionColumns()
        {
            dataGridView.Columns.Clear();

            AddColumn("TransactionId", "ID", 50);
            AddColumn("Account", "Account", 100);
            AddColumn("Amount", "Amount", 80);
            AddColumn("CreatedAt", "Date", 100);

            AddDeleteButtonColumn();
        }

        private void AddColumn(string propertyName, string headerText, int width)
        {
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = propertyName,
                HeaderText = headerText,
                Width = width,
                ReadOnly = true
            });
        }

        private void AddDeleteButtonColumn()
        {
            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            dataGridView.Columns.Add(deleteColumn);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentViewMode == ViewMode.Customers)
                {
                    AddCustomer();
                }
                else
                {
                    AddTransaction();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentViewMode == ViewMode.Customers)
                {
                    EditCustomer();
                }
                else
                {
                    EditTransaction();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCustomer()
        {
            using (var form = new AddCustomerForm(_unitOfWork))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
        }

        private void EditCustomer()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is not Customer selectedCustomer)
            {
                MessageBox.Show("Please select a customer to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new EditCustomerForm(_unitOfWork, selectedCustomer.CustomerId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
        }

        private void AddTransaction()
        {
            using (var form = new AddTransactionForm(_unitOfWork))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void EditTransaction()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is not Transaction selectedTransaction)
            {
                MessageBox.Show("Please select a transaction to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new EditTransactionForm(_unitOfWork, selectedTransaction.TransactionId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeleteRecord(e.RowIndex);
            }
        }

        private void DeleteRecord(int rowIndex)
        {
            try
            {
                var record = dataGridView.Rows[rowIndex].DataBoundItem;
                string recordType = _currentViewMode == ViewMode.Customers ? "customer" : "transaction";
                string recordName = _currentViewMode == ViewMode.Customers ?
                    ((Customer)record).CustomerName : $"Transaction #{((Transaction)record).TransactionId}";

                var result = MessageBox.Show(
                    $"Are you sure you want to delete {recordName}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    if (_currentViewMode == ViewMode.Customers)
                    {
                        var customer = (Customer)record;
                        _unitOfWork.Customers.Remove(customer);
                    }
                    else
                    {
                        var transaction = (Transaction)record;
                        _unitOfWork.Transactions.Remove(transaction);
                    }

                    _unitOfWork.Complete();
                    LoadData();

                    MessageBox.Show($"{recordType} deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (_currentViewMode == ViewMode.Customers)
            {
                EditCustomer();
            }
            else
            {
                EditTransaction();
            }
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font =
                    new Font(dataGridView.Font, FontStyle.Bold);
            }

            //format amount column for transactions
            if (_currentViewMode == ViewMode.Transactions &&
                dataGridView.Columns[e.ColumnIndex].DataPropertyName == "Amount")
            {
                if (e.Value is decimal amount)
                {
                    e.Value = amount.ToString("C2");
                    e.FormattingApplied = true;
                }
            }

            //format date columns
            if (dataGridView.Columns[e.ColumnIndex].DataPropertyName == "CreatedDate" ||
                dataGridView.Columns[e.ColumnIndex].DataPropertyName == "TransactionDate")
            {
                if (e.Value is DateTime date)
                {
                    e.Value = date.ToString("yyyy-MM-dd");
                    e.FormattingApplied = true;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _unitOfWork?.Dispose();
            base.OnFormClosing(e);
        }

        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
