using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class DataBillModel
    {
        public int SalesManID { get; set; }
        public Bill Bill { get; set; }
        public Customer Customer { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
        public int ProductID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}