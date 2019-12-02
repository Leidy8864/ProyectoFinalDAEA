using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WEB.Helpers
{
    public static class ApiUrlHelper
    {
        public static string BaseUrl()
        {
            string url = ConfigurationManager.AppSettings["Url"];
            string port = ConfigurationManager.AppSettings["Port"];
            string baseUrl = url + port;

            return baseUrl;
        }
    }
}