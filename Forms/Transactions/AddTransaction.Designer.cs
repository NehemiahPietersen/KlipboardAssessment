namespace CustomerManager.Forms.Transactions
{
    partial class AddTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TransactionAmountTxtBox = new TextBox();
            CancelBtn = new Button();
            SaveTransactioinBtn = new Button();
            TransactionRefTxtBox = new TextBox();
            TransactionDatePicker = new DateTimePicker();
            DebitRadioBtn = new RadioButton();
            CreditRadioBtn = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 0;
            label1.Text = "Add A Transaction";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 73);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 1;
            label2.Text = "Transaction Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 123);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 2;
            label3.Text = "Transaction Reference";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 173);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 3;
            label4.Text = "Transaction Amount";
            // 
            // TransactionAmountTxtBox
            // 
            TransactionAmountTxtBox.Location = new Point(31, 191);
            TransactionAmountTxtBox.Name = "TransactionAmountTxtBox";
            TransactionAmountTxtBox.Size = new Size(217, 23);
            TransactionAmountTxtBox.TabIndex = 4;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(31, 303);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(98, 30);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // SaveTransactioinBtn
            // 
            SaveTransactioinBtn.Location = new Point(145, 303);
            SaveTransactioinBtn.Name = "SaveTransactioinBtn";
            SaveTransactioinBtn.Size = new Size(144, 30);
            SaveTransactioinBtn.TabIndex = 6;
            SaveTransactioinBtn.Text = "Confirm Transaction";
            SaveTransactioinBtn.UseVisualStyleBackColor = true;
            SaveTransactioinBtn.Click += SaveTransactioinBtn_Click;
            // 
            // TransactionRefTxtBox
            // 
            TransactionRefTxtBox.Location = new Point(31, 141);
            TransactionRefTxtBox.Name = "TransactionRefTxtBox";
            TransactionRefTxtBox.Size = new Size(217, 23);
            TransactionRefTxtBox.TabIndex = 7;
            // 
            // TransactionDatePicker
            // 
            TransactionDatePicker.Location = new Point(31, 91);
            TransactionDatePicker.Name = "TransactionDatePicker";
            TransactionDatePicker.Size = new Size(200, 23);
            TransactionDatePicker.TabIndex = 8;
            // 
            // DebitRadioBtn
            // 
            DebitRadioBtn.AutoSize = true;
            DebitRadioBtn.Location = new Point(31, 246);
            DebitRadioBtn.Name = "DebitRadioBtn";
            DebitRadioBtn.Size = new Size(53, 19);
            DebitRadioBtn.TabIndex = 9;
            DebitRadioBtn.TabStop = true;
            DebitRadioBtn.Text = "Debit";
            DebitRadioBtn.UseVisualStyleBackColor = true;
            // 
            // CreditRadioBtn
            // 
            CreditRadioBtn.AutoSize = true;
            CreditRadioBtn.Location = new Point(113, 246);
            CreditRadioBtn.Name = "CreditRadioBtn";
            CreditRadioBtn.Size = new Size(57, 19);
            CreditRadioBtn.TabIndex = 10;
            CreditRadioBtn.TabStop = true;
            CreditRadioBtn.Text = "Credit";
            CreditRadioBtn.UseVisualStyleBackColor = true;
            // 
            // AddTransaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CreditRadioBtn);
            Controls.Add(DebitRadioBtn);
            Controls.Add(TransactionDatePicker);
            Controls.Add(TransactionRefTxtBox);
            Controls.Add(SaveTransactioinBtn);
            Controls.Add(CancelBtn);
            Controls.Add(TransactionAmountTxtBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddTransaction";
            Text = "Add Transaction";
            Load += AddTransaction_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TransactionAmountTxtBox;
        private Button CancelBtn;
        private Button SaveTransactioinBtn;
        private TextBox TransactionRefTxtBox;
        private DateTimePicker TransactionDatePicker;
        private RadioButton DebitRadioBtn;
        private RadioButton CreditRadioBtn;
    }
}