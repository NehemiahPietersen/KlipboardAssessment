using CustomerManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlipBoardAssessment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        private readonly string _databasePath;

        public ApplicationDbContext()
        {
            var folderPath = Environment.CurrentDirectory;
            _databasePath = Path.Combine(folderPath, "customerManagerDB.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure relationships
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.Account)
                .HasPrincipalKey(c => c.Account);

            base.OnModelCreating(modelBuilder);
        }

        public bool DatabaseExists()
        {
            return File.Exists(_databasePath);
        }
    }
}
