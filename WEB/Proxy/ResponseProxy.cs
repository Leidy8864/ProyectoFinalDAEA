using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Proxy
{
    public class ResponseProxy<TEntity> : ICloneable where TEntity : class, new() 
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<TEntity> List { get; set; }
        public TEntity Object { get; set; }
        public bool Status { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}