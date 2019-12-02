using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public string FullName => $"{Name} {LastName}";
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
