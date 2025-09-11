namespace KlipBoardAssessment
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
            CustomerLabel = new Label();
            customerAccountLabel = new Label();
            CustomerNameLabel = new Label();
            customerAccountTextBox = new TextBox();
            CustomerNameTextBox = new TextBox();
            SaveCustomerButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // CustomerLabel
            // 
            CustomerLabel.AutoSize = true;
            CustomerLabel.Location = new Point(27, 29);
            CustomerLabel.Name = "CustomerLabel";
            CustomerLabel.Size = new Size(150, 20);
            CustomerLabel.TabIndex = 0;
            CustomerLabel.Text = "Add a New Customer";
            CustomerLabel.Click += label1_Click;
            // 
            // customerAccountLabel
            // 
            customerAccountLabel.AutoSize = true;
            customerAccountLabel.Location = new Point(27, 99);
            customerAccountLabel.Name = "customerAccountLabel";
            customerAccountLabel.Size = new Size(188, 20);
            customerAccountLabel.TabIndex = 1;
            customerAccountLabel.Text = "Customer Account Number";
            // 
            // CustomerNameLabel
            // 
            CustomerNameLabel.AutoSize = true;
            CustomerNameLabel.Location = new Point(27, 188);
            CustomerNameLabel.Name = "CustomerNameLabel";
            CustomerNameLabel.Size = new Size(116, 20);
            CustomerNameLabel.TabIndex = 2;
            CustomerNameLabel.Text = "Customer Name";
            // 
            // customerAccountTextBox
            // 
            customerAccountTextBox.Location = new Point(27, 122);
            customerAccountTextBox.MaxLength = 15;
            customerAccountTextBox.Name = "customerAccountTextBox";
            customerAccountTextBox.PlaceholderText = "Ex. AC678#2v";
            customerAccountTextBox.Size = new Size(384, 27);
            customerAccountTextBox.TabIndex = 5;
            // 
            // CustomerNameTextBox
            // 
            CustomerNameTextBox.Location = new Point(27, 211);
            CustomerNameTextBox.MaxLength = 30;
            CustomerNameTextBox.Name = "CustomerNameTextBox";
            CustomerNameTextBox.PlaceholderText = "Ex. William Holdings";
            CustomerNameTextBox.Size = new Size(384, 27);
            CustomerNameTextBox.TabIndex = 6;
            // 
            // SaveCustomerButton
            // 
            SaveCustomerButton.Location = new Point(27, 317);
            SaveCustomerButton.Name = "SaveCustomerButton";
            SaveCustomerButton.Size = new Size(137, 53);
            SaveCustomerButton.TabIndex = 8;
            SaveCustomerButton.Text = "Save Customer";
            SaveCustomerButton.UseVisualStyleBackColor = true;
            SaveCustomerButton.Click += SaveCustomerButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(188, 317);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(156, 53);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 457);
            Controls.Add(CancelButton);
            Controls.Add(SaveCustomerButton);
            Controls.Add(CustomerNameTextBox);
            Controls.Add(customerAccountTextBox);
            Controls.Add(CustomerNameLabel);
            Controls.Add(customerAccountLabel);
            Controls.Add(CustomerLabel);
            Name = "AddCustomer";
            Text = "AddCustomer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CustomerLabel;
        private Label customerAccountLabel;
        private Label CustomerNameLabel;
        private TextBox customerAccountTextBox;
        private TextBox CustomerNameTextBox;
        private Button SaveCustomerButton;
        private Button CancelButton;
    }
}