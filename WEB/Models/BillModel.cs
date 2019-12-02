using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class BillModel
    {
        public int BillID { get; set; }
        public string Code { get; set; }
        public string Comments { get; set; }
        public int IGV { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CustomerID { get; set; }
        public int SalesManID { get; set; }
    }
}