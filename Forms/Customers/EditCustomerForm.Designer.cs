namespace KlipBoardAssessment.Forms.Customers
{
    partial class EditCustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlContent;
        private Label lblName;
        private TextBox txtName;
        private Label lblAccount;
        private TextBox txtAccount;
        private Label lblBalance;
        private Label lblBalanceValue;
        private Label lblCreatedAt;
        private Label lblCreatedAtValue;
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
        //    this.Text = "EditCustomerForm";
        //}

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlContent = new Panel();
            lblCreatedAtValue = new Label();
            lblCreatedAt = new Label();
            lblBalanceValue = new Label();
            lblBalance = new Label();
            txtAccount = new TextBox();
            lblAccount = new Label();
            txtName = new TextBox();
            lblName = new Label();
            pnlButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
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
            lblTitle.Size = new Size(137, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Edit Customer";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(lblCreatedAtValue);
            pnlContent.Controls.Add(lblCreatedAt);
            pnlContent.Controls.Add(lblBalanceValue);
            pnlContent.Controls.Add(lblBalance);
            pnlContent.Controls.Add(txtAccount);
            pnlContent.Controls.Add(lblAccount);
            pnlContent.Controls.Add(txtName);
            pnlContent.Controls.Add(lblName);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 60);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(30);
            pnlContent.Size = new Size(500, 220);
            pnlContent.TabIndex = 1;
            // 
            // lblCreatedAtValue
            // 
            lblCreatedAtValue.AutoSize = true;
            lblCreatedAtValue.Location = new Point(130, 160);
            lblCreatedAtValue.Name = "lblCreatedAtValue";
            lblCreatedAtValue.Size = new Size(64, 15);
            lblCreatedAtValue.TabIndex = 7;
            lblCreatedAtValue.Text = "2024-01-01";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.AutoSize = true;
            lblCreatedAt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCreatedAt.Location = new Point(30, 160);
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new Size(68, 15);
            lblCreatedAt.TabIndex = 6;
            lblCreatedAt.Text = "Created At:";
            // 
            // lblBalanceValue
            // 
            lblBalanceValue.AutoSize = true;
            lblBalanceValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBalanceValue.ForeColor = Color.Green;
            lblBalanceValue.Location = new Point(130, 120);
            lblBalanceValue.Name = "lblBalanceValue";
            lblBalanceValue.Size = new Size(34, 15);
            lblBalanceValue.TabIndex = 5;
            lblBalanceValue.Text = "$0.00";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBalance.Location = new Point(30, 120);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(53, 15);
            lblBalance.TabIndex = 4;
            lblBalance.Text = "Balance:";
            // 
            // txtAccount
            // 
            txtAccount.Location = new Point(130, 70);
            txtAccount.MaxLength = 15;
            txtAccount.Name = "txtAccount";
            txtAccount.ReadOnly = true;
            txtAccount.Size = new Size(250, 23);
            txtAccount.TabIndex = 1;
            txtAccount.TabStop = false;
            txtAccount.BackColor = SystemColors.Control;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(30, 73);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(55, 15);
            lblAccount.TabIndex = 2;
            lblAccount.Text = "Account:";
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 20);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 23);
            txtName.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(30, 23);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = SystemColors.Control;
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 280);
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
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Location = new Point(270, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 35);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // EditCustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 350);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlButtons);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditCustomerForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Customer";
            Load += EditCustomerForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}