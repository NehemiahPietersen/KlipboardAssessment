namespace KlipBoardAssessment
{
    partial class CustomerManagerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerManagerForm));
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            AddCustomerButton = new Button();
            dataGridView1 = new DataGridView();
            EditCustomerButton = new Button();
            DeleteCustomerButton = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            SearchButton = new Button();
            SortByButton = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(SortByButton);
            splitContainer1.Panel2.Controls.Add(SearchButton);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(DeleteCustomerButton);
            splitContainer1.Panel2.Controls.Add(EditCustomerButton);
            splitContainer1.Panel2.Controls.Add(AddCustomerButton);
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            // 
            // treeView1
            // 
            resources.ApplyResources(treeView1, "treeView1");
            treeView1.Name = "treeView1";
            treeView1.Nodes.AddRange(new TreeNode[] { (TreeNode)resources.GetObject("treeView1.Nodes"), (TreeNode)resources.GetObject("treeView1.Nodes1") });
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // AddCustomerButton
            // 
            resources.ApplyResources(AddCustomerButton, "AddCustomerButton");
            AddCustomerButton.Name = "AddCustomerButton";
            AddCustomerButton.UseVisualStyleBackColor = true;
            AddCustomerButton.Click += AddCustomerButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.Name = "dataGridView1";
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // EditCustomerButton
            // 
            resources.ApplyResources(EditCustomerButton, "EditCustomerButton");
            EditCustomerButton.Name = "EditCustomerButton";
            EditCustomerButton.UseVisualStyleBackColor = true;
            // 
            // DeleteCustomerButton
            // 
            resources.ApplyResources(DeleteCustomerButton, "DeleteCustomerButton");
            DeleteCustomerButton.Name = "DeleteCustomerButton";
            DeleteCustomerButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.Name = "textBox1";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // SearchButton
            // 
            resources.ApplyResources(SearchButton, "SearchButton");
            SearchButton.Name = "SearchButton";
            SearchButton.UseVisualStyleBackColor = true;
            // 
            // SortByButton
            // 
            resources.ApplyResources(SortByButton, "SortByButton");
            SortByButton.Name = "SortByButton";
            SortByButton.UseVisualStyleBackColor = true;
            // 
            // CustomerManagerForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "CustomerManagerForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private DataGridView dataGridView1;
        private Button AddCustomerButton;
        private Button DeleteCustomerButton;
        private Button EditCustomerButton;
        private Label label1;
        private TextBox textBox1;
        private Button SortByButton;
        private Button SearchButton;
    }
}
