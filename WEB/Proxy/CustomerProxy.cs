using WEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WEB.Helpers;

namespace WEB.Proxy
{
    public class CustomerProxy
    {
        public async Task<ResponseProxy<CustomerModel>> GetCustomersAsync()
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/", "Customer/", "GetAllCustomers");
            var response = client.GetAsync(url).Result; 
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var Customers = JsonConvert.DeserializeObject<List<CustomerModel>>(result);
                return new ResponseProxy<CustomerModel>
                {
                    Status = true,
                    Code = (int)HttpStatusCode.OK,
                    Message = "Status",
                    List = Customers
                };
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }

        public async Task<ResponseProxy<CustomerModel>> InsertAsync(CustomerModel Customer)
        {
            var request = JsonConvert.SerializeObject(Customer);
            var content = new StringContent(request, Encoding.UTF8, "application/json");



            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, "/api/Customer/InsertCustomer");

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new ResponseProxy<CustomerModel>
                {
                    Status = exito,
                    Code = 0,
                    Message = "Exito"
                };
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Status = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<ResponseProxy<CustomerModel>> UpdateAsync(CustomerModel Customer)
        {
            var request = JsonConvert.SerializeObject(Customer);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl); 

            var url = string.Concat(baseUrl, "/api/Customer/UpdateCustomer");

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new ResponseProxy<CustomerModel>
                {
                    Status = exito,
                    Code = 0,
                    Message = "Exito"
                };
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Status = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<ResponseProxy<CustomerModel>> DetailCustomerAsync(int ID)
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/", "Customer/", "GetCustomer/", ID);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var Customer = JsonConvert.DeserializeObject<CustomerModel>(result);
                return new ResponseProxy<CustomerModel>
                {
                    Status = true,
                    Code = (int)HttpStatusCode.OK,
                    Message = "Status",
                    Object = Customer
                };
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<ResponseProxy<CustomerModel>> DeleteCustomerAsync(int ID)
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/", "Customer/", "DeleteCustomer/", ID);
            var response = client.DeleteAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new ResponseProxy<CustomerModel>
                {
                    Status = exito,
                    Code = 0,
                    Message = "Exito"
                };
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Status = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }

        public async Task<ResponseProxy<CustomerModel>> SearchCustomersAsync(string query)
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/", "Customer/", "SearchCustomers?query=", query);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var Customers = JsonConvert.DeserializeObject<List<CustomerModel>>(result);
                return new ResponseProxy<CustomerModel>
                {
                    Status = true,
                    Code = (int)HttpStatusCode.OK,
                    Message = "Status",
                    List = Customers
                };
            }
            else
            {
                return new ResponseProxy<CustomerModel>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}