using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlipBoardAssessment.models
{
    internal class Customer
    {
        public int Id { get; set; }
        public required string Account {  get; set; }
        public required string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
