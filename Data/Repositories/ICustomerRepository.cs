using CustomerManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByAccountAsync(string account);
        Customer GetCustomerByAccount(string? account);
        Task<IEnumerable<Customer>> GetCustomerWithTransacionsAsync();
    }
}
