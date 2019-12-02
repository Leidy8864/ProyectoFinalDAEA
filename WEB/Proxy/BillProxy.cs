using Common.HttpHelpers;
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
using WEB.Models;

namespace WEB.Proxy
{
    public class BillProxy
    {
        public async Task<EResponseBase<CustomBillModel>> GetBillsAsync()
        {
            try
            {
                var client = new HttpClient();
                string baseUrl = ApiUrlHelper.BaseUrl();
                client.BaseAddress = new Uri(baseUrl);

                var url = string.Concat(baseUrl, "/api/", "Bill/", "GetAllBills");
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EResponseBase<CustomBillModel>>(result);
                }
                else
                {
                    return new EResponseBase<CustomBillModel>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new EResponseBase<CustomBillModel>
                {
                    Code = 404,
                    Message = ex.Message
                };
                throw;
            }
        }

        public async Task<EResponseBase<DataBillModel>> InsertAsync(DataBillModel order)
        {
            try
            {
                var request = JsonConvert.SerializeObject(order);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                string baseUrl = ApiUrlHelper.BaseUrl();
                client.BaseAddress = new Uri(baseUrl);
                var url = string.Concat(baseUrl, "/api/Bill/InsertBill");

                var response = client.PostAsync(url, content).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var exito = JsonConvert.DeserializeObject<bool>(result);
                    return new EResponseBase<DataBillModel>
                    {
                        Status = exito,
                        Code = 0,
                        Message = "Exito"
                    };
                }
                else
                {
                    return new EResponseBase<DataBillModel>
                    {
                        Status = false,
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new EResponseBase<DataBillModel>
                {
                    Code = 404,
                    Message = ex.Message
                };
                throw;
            }
        }
        public async Task<EResponseBase<CustomBillModel>> UpdateAsync(CustomBillModel Customer)
        {
            var request = JsonConvert.SerializeObject(Customer);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/Bill/UpdateBill");

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new EResponseBase<CustomBillModel>
                {
                    Status = exito,
                    Code = 0,
                    Message = "Exito"
                };
            }
            else
            {
                return new EResponseBase<CustomBillModel>
                {
                    Status = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<CustomBillModel>> DetailCustomerAsync(int ID)
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/", "Bill/", "GetBill/", ID);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var Customer = JsonConvert.DeserializeObject<CustomBillModel>(result);
                return new EResponseBase<CustomBillModel>
                {
                    Status = true,
                    Code = (int)HttpStatusCode.OK,
                    Message = "Status",
                    Object = Customer
                };
            }
            else
            {
                return new EResponseBase<CustomBillModel>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<CustomBillModel>> DeleteCustomerAsync(int ID)
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/", "Bill/", "DeleteBill/", ID);
            var response = client.DeleteAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new EResponseBase<CustomBillModel>
                {
                    Status = exito,
                    Code = 0,
                    Message = "Exito"
                };
            }
            else
            {
                return new EResponseBase<CustomBillModel>
                {
                    Status = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }

        //public async Task<EResponseBase<CustomBillModel>> SearchCustomersAsync(string query)
        //{
        //    var client = new HttpClient();
        //    string baseUrl = ApiUrlHelper.BaseUrl();
        //    client.BaseAddress = new Uri(baseUrl);

        //    var url = string.Concat(baseUrl, "/api/", "Bill/", "SearchCustomers?query=", query);
        //    var response = client.GetAsync(url).Result;
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        var result = await response.Content.ReadAsStringAsync();
        //        var Customers = JsonConvert.DeserializeObject<List<CustomBillModel>>(result);
        //        return new EResponseBase<CustomBillModel>
        //        {
        //            Status = true,
        //            Code = (int)HttpStatusCode.OK,
        //            Message = "Status",
        //            List = Customers
        //        };
        //    }
        //    else
        //    {
        //        return new EResponseBase<CustomBillModel>
        //        {
        //            Code = (int)response.StatusCode,
        //            Message = "Error"
        //        };
        //    }
        //}
    }
}