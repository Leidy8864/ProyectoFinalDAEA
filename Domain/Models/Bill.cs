using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }
        [Required]
        public string Code { get; set; }
        public string Comments { get; set; }
        public decimal IGV { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerID { get; set; }
        public int SalesManID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual SalesMan SalesMan { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }


    }
}
