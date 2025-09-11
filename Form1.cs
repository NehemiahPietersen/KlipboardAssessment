namespace KlipBoardAssessment
{
    public partial class CustomerManagerForm : Form
    {
        public CustomerManagerForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomer form = new AddCustomer();
            form.ShowDialog(this);
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
