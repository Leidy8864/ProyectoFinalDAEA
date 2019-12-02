using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SalesMan
    {
        [Key]
        public int SalesManID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public string FullName => $"{Name} {LastName}";
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
