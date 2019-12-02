using Common.HttpHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Proxy
{
    public class ProductProxy
    {
        public async Task<EResponseBase<ProductModel>> GetProductsAsync()
        {
            try
            {
                var client = new HttpClient();
                string baseUrl = ApiUrlHelper.BaseUrl();
                client.BaseAddress = new Uri(baseUrl);

                var url = string.Concat(baseUrl, "/api/", "Products/", "GetAllProducts");
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EResponseBase<ProductModel>>(result);
                }
                else
                {
                    return new EResponseBase<ProductModel>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new EResponseBase<ProductModel>
                {
                    Code = 404,
                    Message = ex.Message
                };
                throw;
            }
        }
    }
}