using KlipBoardAssessment.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlipBoardAssessment.Forms.Transactions
{
    public partial class EditTransactionForm : Form
    {
        private UnitOfWork _unitOfWork;
        private int _transactionId;

        public EditTransactionForm(UnitOfWork unitOfWork, int transactionId)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork; //incase needed in future
            _transactionId = transactionId; //incase needed in future

            btnGoBack.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }
}
