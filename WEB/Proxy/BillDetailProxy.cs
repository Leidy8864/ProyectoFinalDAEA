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
    public class BillDetailProxy
    {
        public async Task<EResponseBase<BillDetailProxy>> GetBillsAsync()
        {
            try
            {
                var client = new HttpClient();
                string baseUrl = ApiUrlHelper.BaseUrl();
                client.BaseAddress = new Uri(baseUrl);

                var url = string.Concat(baseUrl, "/api/", "BillDetail/", "GetAllBillDetails");
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EResponseBase<BillDetailProxy>>(result);
                }
                else
                {
                    return new EResponseBase<BillDetailProxy>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new EResponseBase<BillDetailProxy>
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
                var url = string.Concat(baseUrl, "/api/BillDetail/InsertBillDetail");

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
        public async Task<EResponseBase<BillDetailProxy>> UpdateAsync(BillDetailProxy BillDetail)
        {
            var request = JsonConvert.SerializeObject(BillDetail);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/BillDetail/UpdateBillDetail");

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new EResponseBase<BillDetailProxy>
                {
                    Status = exito,
                    Code = 0,
                    Message = "Exito"
                };
            }
            else
            {
                return new EResponseBase<BillDetailProxy>
                {
                    Status = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<BillDetailProxy>> DetailCustomerAsync(int ID)
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/", "BillDetail/", "GetBillDetail/", ID);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var BillDetail = JsonConvert.DeserializeObject<BillDetailProxy>(result);
                return new EResponseBase<BillDetailProxy>
                {
                    Status = true,
                    Code = (int)HttpStatusCode.OK,
                    Message = "Status",
                    Object = BillDetail
                };
            }
            else
            {
                return new EResponseBase<BillDetailProxy>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<EResponseBase<BillDetailProxy>> DeleteCustomerAsync(int ID)
        {
            var client = new HttpClient();
            string baseUrl = ApiUrlHelper.BaseUrl();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, "/api/", "BillDetail/", "DeleteBillDetail/", ID);
            var response = client.DeleteAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var exito = JsonConvert.DeserializeObject<bool>(result);
                return new EResponseBase<BillDetailProxy>
                {
                    Status = exito,
                    Code = 0,
                    Message = "Exito"
                };
            }
            else
            {
                return new EResponseBase<BillDetailProxy>
                {
                    Status = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}