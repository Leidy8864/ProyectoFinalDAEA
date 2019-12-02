using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomModels
{
    public class DataBill
    {
        public int SalesManID { get; set; }
        public Bill Bill { get; set; }
        public Customer Customer { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
        public int ProductID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
