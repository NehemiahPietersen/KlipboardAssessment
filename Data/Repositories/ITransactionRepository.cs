using CustomerManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Data.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<Transaction> GetByAccountAsync(string accountNumber);
        Task<IEnumerable<Transaction>> GetTransactionByCustomerAccountAsync(string account);
        Task<IEnumerable<Transaction>> GetTransactionsBasedOnTransactionTypeAsync(char userValue);
    }
}
