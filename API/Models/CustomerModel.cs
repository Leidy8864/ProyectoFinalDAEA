using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repository
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FullName => $"{Name} {LastName}";
    }
}