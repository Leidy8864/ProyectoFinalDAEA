using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repository
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool State { get; set; }
    }
}