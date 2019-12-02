using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repository
{
    public class BillDetailModel
    {
        public int BillDetailID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool State { get; set; }
        public int ProductID { get; set; }
        public int BillID { get; set; }
    }
}