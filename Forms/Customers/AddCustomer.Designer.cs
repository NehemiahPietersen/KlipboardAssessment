namespace CustomerManager.Forms
{
    partial class AddCustomer
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
            customerNameTxtBox = new TextBox();
            customerAccTxtBox = new TextBox();
            CancelBtn = new Button();
            SaveBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(249, 15);
            label1.TabIndex = 0;
            label1.Text = "To Add  a Customer Please fill in the following";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 1;
            label2.Text = "Customer Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 127);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 2;
            label3.Text = "Customer Account";
            // 
            // customerNameTxtBox
            // 
            customerNameTxtBox.Location = new Point(12, 84);
            customerNameTxtBox.Name = "customerNameTxtBox";
            customerNameTxtBox.Size = new Size(436, 23);
            customerNameTxtBox.TabIndex = 3;
            // 
            // customerAccTxtBox
            // 
            customerAccTxtBox.Location = new Point(12, 155);
            customerAccTxtBox.Name = "customerAccTxtBox";
            customerAccTxtBox.Size = new Size(436, 23);
            customerAccTxtBox.TabIndex = 4;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(12, 382);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 38);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(129, 382);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(108, 38);
            SaveBtn.TabIndex = 6;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // AddCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SaveBtn);
            Controls.Add(CancelBtn);
            Controls.Add(customerAccTxtBox);
            Controls.Add(customerNameTxtBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddCustomer";
            Text = "Add Customer";
            Load += AddCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox customerNameTxtBox;
        private TextBox customerAccTxtBox;
        private Button CancelBtn;
        private Button SaveBtn;
    }
}