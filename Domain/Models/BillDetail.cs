using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BillDetail
    {
        [Key]
        public int BillDetailID { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool State { get; set; }
        public int ProductID { get; set; }
        public int BillID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
