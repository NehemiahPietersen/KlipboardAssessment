namespace KlipBoardAssessment.Forms.Transactions
{
    partial class EditTransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblMessage;
        private Button btnGoBack;

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
        //    this.Text = "EditTransactionForm";
        //}

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(350, 200);
            this.Text = "Edit Transaction";
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;

            //Message Label
            lblMessage = new Label();
            lblMessage.Text = "NOT IN USE\r\n\r\nThis feature is not available.";
            lblMessage.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMessage.ForeColor = Color.Gray;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Dock = DockStyle.Fill;
            this.Controls.Add(lblMessage);

            //Go Back Button
            btnGoBack = new Button();
            btnGoBack.Text = "Go Back";
            btnGoBack.Size = new Size(100, 35);
            btnGoBack.Location = new Point(125, 150);
            btnGoBack.Anchor = AnchorStyles.Bottom;
            this.Controls.Add(btnGoBack);
        }

    #endregion
    }
}