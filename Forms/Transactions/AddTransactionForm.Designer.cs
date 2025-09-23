namespace KlipBoardAssessment.Forms.Transactions
{
    partial class AddTransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlContent;
        private Label lblCustomer;
        private ComboBox cmbCustomer;
        private Label lblAmount;
        private TextBox txtAmount;
        private Label lblTransactionType;
        private Panel pnlTransactionType;
        private RadioButton rdbDebit;
        private RadioButton rdbCredit;
        private Label lblDate;
        private DateTimePicker dtpTransactionDate;
        private Panel pnlButtons;
        private Button btnSave;
        private Button btnCancel;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Text = "AddTransactionForm";
        //}

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlContent = new Panel();
            dtpTransactionDate = new DateTimePicker();
            lblDate = new Label();
            pnlTransactionType = new Panel();
            rdbCredit = new RadioButton();
            rdbDebit = new RadioButton();
            lblTransactionType = new Label();
            txtAmount = new TextBox();
            lblAmount = new Label();
            cmbCustomer = new ComboBox();
            lblCustomer = new Label();
            pnlButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlTransactionType.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.LightSteelBlue;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 10, 20, 10);
            pnlHeader.Size = new Size(500, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkSlateBlue;
            lblTitle.Location = new Point(16, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(156, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Transaction";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(dtpTransactionDate);
            pnlContent.Controls.Add(lblDate);
            pnlContent.Controls.Add(pnlTransactionType);
            pnlContent.Controls.Add(lblTransactionType);
            pnlContent.Controls.Add(txtAmount);
            pnlContent.Controls.Add(lblAmount);
            pnlContent.Controls.Add(cmbCustomer);
            pnlContent.Controls.Add(lblCustomer);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 60);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(30);
            pnlContent.Size = new Size(500, 320);
            pnlContent.TabIndex = 1;
            // 
            // dtpTransactionDate
            // 
            dtpTransactionDate.Location = new Point(150, 150);
            dtpTransactionDate.Name = "dtpTransactionDate";
            dtpTransactionDate.Size = new Size(200, 23);
            dtpTransactionDate.TabIndex = 3;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(30, 153);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 6;
            lblDate.Text = "Date:";
            // 
            // pnlTransactionType
            // 
            pnlTransactionType.Controls.Add(rdbCredit);
            pnlTransactionType.Controls.Add(rdbDebit);
            pnlTransactionType.Location = new Point(150, 100);
            pnlTransactionType.Name = "pnlTransactionType";
            pnlTransactionType.Size = new Size(200, 30);
            pnlTransactionType.TabIndex = 5;
            // 
            // rdbCredit
            // 
            rdbCredit.AutoSize = true;
            rdbCredit.Location = new Point(100, 5);
            rdbCredit.Name = "rdbCredit";
            rdbCredit.Size = new Size(56, 19);
            rdbCredit.TabIndex = 2;
            rdbCredit.TabStop = true;
            rdbCredit.Text = "Credit";
            rdbCredit.UseVisualStyleBackColor = true;
            // 
            // rdbDebit
            // 
            rdbDebit.AutoSize = true;
            rdbDebit.Location = new Point(10, 5);
            rdbDebit.Name = "rdbDebit";
            rdbDebit.Size = new Size(53, 19);
            rdbDebit.TabIndex = 1;
            rdbDebit.TabStop = true;
            rdbDebit.Text = "Debit";
            rdbDebit.UseVisualStyleBackColor = true;
            // 
            // lblTransactionType
            // 
            lblTransactionType.AutoSize = true;
            lblTransactionType.Location = new Point(30, 105);
            lblTransactionType.Name = "lblTransactionType";
            lblTransactionType.Size = new Size(34, 15);
            lblTransactionType.TabIndex = 4;
            lblTransactionType.Text = "Type:";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(150, 60);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(150, 23);
            txtAmount.TabIndex = 1;
            txtAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(30, 63);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(54, 15);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "Amount:";
            // 
            // cmbCustomer
            // 
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(150, 20);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(290, 23);
            cmbCustomer.TabIndex = 0;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(30, 23);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(62, 15);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer:";
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = SystemColors.Control;
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 380);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(20);
            pnlButtons.Size = new Size(500, 70);
            pnlButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(370, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 35);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Location = new Point(270, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 35);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // AddTransactionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 450);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlButtons);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTransactionForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Transaction";
            Load += AddTransactionForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlTransactionType.ResumeLayout(false);
            pnlTransactionType.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion
    }
}