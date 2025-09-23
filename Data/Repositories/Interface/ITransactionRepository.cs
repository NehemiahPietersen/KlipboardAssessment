using CustomerManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlipBoardAssessment.Data.Repositories.Interface
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetTransactionsByAccount(string accountNumber);
        decimal GetAccountBalance(string accountNumber);
        IEnumerable<Transaction> GetAllWithCustomers();

    }
}
