using KlipBoardAssessment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlipBoardAssessment.Services
{
    public class DatabaseInitializer
    {
        private readonly ApplicationDbContext _context;

        public DatabaseInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            //Check if database exists
            if (!_context.DatabaseExists())
            {
                Console.WriteLine("Creating database and tables...");

                //Create database and tables
                _context.Database.EnsureCreated();

                SeedInitialData();
            }
            else
            {
                Console.WriteLine("Database already exists. Applying migrations if any...");
                _context.Database.Migrate();
            }
        }

        private void SeedInitialData()
        {
            // Add initial seed data if needed
            Console.WriteLine("Database created successfully!");
        }

    }
}
