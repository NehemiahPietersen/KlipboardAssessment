using CustomerManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Transaction> GetByAccountAsync(string accountNumber)
        {
            return await _context.Transactions
            .FirstOrDefaultAsync(t => t.Account == accountNumber);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionByCustomerAccountAsync(string account)
        {
            return await _context.Transactions
                .Where(t => t.Account == account)
                .Include(t => t.Customer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsBasedOnTransactionTypeAsync(char userValue)
        {
            return await _context.Transactions
                .Where(t => t.TransactionType == userValue)
                .Include(t => t.Customer)
                .ToListAsync();
        }

        //todo maybe getTransactionByDate as well?
    }
}
