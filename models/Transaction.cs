using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlipBoardAssessment.models
{
    internal class Transaction
    {
        public int Id { get; set; }
        public int TransactionNumber { get; set; }
        public required string Account {  get; set; }   
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public char DebitOrCredit { get; set; }
    }
}
