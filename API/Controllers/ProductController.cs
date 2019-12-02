using API.Repository;
using Common.HttpHelpers;
using Domain.Models;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        ProductService Service;
        public ProductController()
        {
            Service = new ProductService();
        }
        [HttpGet]
        public JsonResult<EResponseBase<Product>> GetAllProducts()
        {
            return Json(Service.Get());
        }
        [HttpGet]
        public JsonResult<EResponseBase<Product>> GetProduct(int ID)
        {
            return Json(Service.GetById(ID));
        }
        [HttpPost]
        public JsonResult<EResponseBase<Product>> InsertProduct(Product product)
        {
            return Json(Service.Add(product));
        }
        [HttpPut]
        public JsonResult<EResponseBase<Product>> UpdateProduct(Product product)
        {
            return Json(Service.Update(product));
        }
        [HttpDelete]
        public JsonResult<EResponseBase<Product>> DeleteProduct(int ID)
        {
            return Json(Service.Delete(ID));
        }
    }
}
