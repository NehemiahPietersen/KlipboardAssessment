using CustomerManager.Data.Entities;
using KlipBoardAssessment.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlipBoardAssessment.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }
        public decimal GetAccountBalance(string accountNumber)
        {
            return DbSet.Where(t => t.Account == accountNumber)
                   .Sum(t => t.Amount);
        }

        public IEnumerable<Transaction> GetTransactionsByAccount(string accountNumber)
        {
            return DbSet.Where(t => t.Account == accountNumber)
                   .OrderByDescending(t => t.CreatedAt)
                   .ToList();
        }

        public IEnumerable<Transaction> GetAllWithCustomers()
        {
            return DbSet.Include(t => t.Customer).ToList();
        }

    }
}
