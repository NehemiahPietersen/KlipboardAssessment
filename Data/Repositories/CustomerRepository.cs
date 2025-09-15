using CustomerManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<Customer> GetByAccountAsync(string account)
        {
            return await _context.Customers
                .Where(c => c.Account == account)
                .FirstOrDefaultAsync();
        }

        public Customer GetCustomerByAccount(string? account)
        {
            return _context.Customers.FirstOrDefault(c => c.Account == account);
        }

        public async Task<IEnumerable<Customer>> GetCustomerWithTransacionsAsync()
        {
            return await _context.Customers
                .Include(c => c.Transactions)
                .ToListAsync();
        }
    }
}
