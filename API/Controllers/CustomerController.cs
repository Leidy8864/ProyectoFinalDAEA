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
    public class CustomerController : ApiController
    {
        CustomerService Service;
        public CustomerController()
        {
            Service = new CustomerService();
        }
        [HttpGet]
        public JsonResult<EResponseBase<Customer>> GetAllCustomers()
        {
            return Json(Service.Get());
        }
        [HttpGet]
        public JsonResult<EResponseBase<Customer>> GetCustomer(int ID)
        {
            return Json(Service.GetById(ID));
        }
        [HttpPost]
        public JsonResult<EResponseBase<Customer>> InsertCustomer(Customer customer)
        {
            return Json(Service.Add(customer));
        }
        [HttpPut]
        public JsonResult<EResponseBase<Customer>> UpdateCustomer(Customer customer)
        {
            return Json(Service.Update(customer));
        }
        [HttpDelete]
        public JsonResult<EResponseBase<Customer>> DeleteCustomer(int ID)
        {
            return Json(Service.Delete(ID));
        }
    }
}
