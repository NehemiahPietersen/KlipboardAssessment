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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Customer GetByAccountNumber(string accountNumber)
        {
            return DbSet.FirstOrDefault(c => c.Account == accountNumber);
        }

        public IEnumerable<Customer> GetCustomersWithTransactions()
        {
            return DbSet.Include(c => c.Transactions).ToList();
        }

        public IEnumerable<Customer> GetAllWithTransactions()
        {
            return DbSet.Include(c => c.Transactions).ToList();
        }
    }
}
