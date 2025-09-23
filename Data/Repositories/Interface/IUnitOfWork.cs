using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlipBoardAssessment.Data.Repositories.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        ITransactionRepository Transactions { get; }
        int Complete();
    }
}
