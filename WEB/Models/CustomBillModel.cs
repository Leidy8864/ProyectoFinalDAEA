using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class CustomBillModel
    {
        public int BillID { get; set; }
        public string SalesMan { get; set; }
        public string Customer { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public decimal IGV { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}