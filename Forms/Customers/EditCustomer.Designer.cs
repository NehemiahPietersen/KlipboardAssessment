namespace CustomerManager.Forms
{
    partial class EditCustomer
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
            customerNameTxtBox = new TextBox();
            customerAccTxtBox = new TextBox();
            cancelBtn = new Button();
            saveBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // customerNameTxtBox
            // 
            customerNameTxtBox.Location = new Point(27, 88);
            customerNameTxtBox.Name = "customerNameTxtBox";
            customerNameTxtBox.Size = new Size(343, 23);
            customerNameTxtBox.TabIndex = 0;
            // 
            // customerAccTxtBox
            // 
            customerAccTxtBox.Location = new Point(27, 190);
            customerAccTxtBox.Name = "customerAccTxtBox";
            customerAccTxtBox.Size = new Size(343, 23);
            customerAccTxtBox.TabIndex = 1;
            customerAccTxtBox.TextChanged += customerAccTxtBox_TextChanged;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(27, 279);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(86, 34);
            cancelBtn.TabIndex = 2;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(174, 279);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(130, 35);
            saveBtn.TabIndex = 3;
            saveBtn.Text = "Update Customer";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 24);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 4;
            label1.Text = "Edit A Customer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 70);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 5;
            label2.Text = "Customer Name";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 172);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 6;
            label3.Text = "Customer Account";
            // 
            // EditCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);
            Controls.Add(customerAccTxtBox);
            Controls.Add(customerNameTxtBox);
            Name = "EditCustomer";
            Text = "EditCustomer";
            Load += EditCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox customerNameTxtBox;
        private TextBox customerAccTxtBox;
        private Button cancelBtn;
        private Button saveBtn;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}