using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Data.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(15)]
        public string Account { get; set; }

        public decimal Balance { get; set; } = 0; //default to 0 not null?

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; //don' show though

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
