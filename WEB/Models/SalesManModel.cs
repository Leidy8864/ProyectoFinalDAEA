using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class SalesManModel
    {
        public int SalesManID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FullName { get; set; }
    }
}