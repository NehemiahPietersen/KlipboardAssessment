using CustomerManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CustomerManager.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposal = false;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = new ApplicationDbContext();
            Customers = new CustomerRepository(_context);
            Transactions = new TransactionRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }
        public ITransactionRepository Transactions { get; private set; }

        //CRUD Operations
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void EnsureCreated()
        {
            _context.Database.EnsureCreated();
        }

        public async Task EnsureCreatedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposal)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposal = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ApplicationDbContext GetContext()
        {
            return _context;
        }
    }
}
