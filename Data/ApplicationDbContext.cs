using CustomerManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CustomerManagerLocaldb;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId); 

                entity.HasIndex(c => c.Account) 
                    .IsUnique();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.TransactionId);

                entity.HasOne(t => t.Customer)
                    .WithMany(c => c.Transactions)
                    .HasForeignKey(t => t.Account)
                    .HasPrincipalKey(c => c.Account)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(t => t.Amount)
                    .IsRequired();
            });
        }
    }
}
