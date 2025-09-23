using CustomerManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlipBoardAssessment.Data.Repositories.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByAccountNumber(string accountNumber);
        IEnumerable<Customer> GetCustomersWithTransactions();

        IEnumerable<Customer> GetAllWithTransactions();
    }
}
