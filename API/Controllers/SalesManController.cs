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
    public class SalesManController : ApiController
    {
        SalesManService Service;
        public SalesManController()
        {
            Service = new SalesManService();
        }
        [HttpGet]
        public JsonResult<EResponseBase<SalesMan>> GetAllSalesMans()
        {
            return Json(Service.Get());
        }
        [HttpGet]
        public JsonResult<EResponseBase<SalesMan>> GetSalesMan(int ID)
        {
            return Json(Service.GetById(ID));
        }
        [HttpPost]
        public JsonResult<EResponseBase<SalesMan>> InsertSalesMan(SalesMan SalesMan)
        {
            return Json(Service.Add(SalesMan));
        }
        [HttpPut]
        public JsonResult<EResponseBase<SalesMan>> UpdateSalesMan(SalesMan SalesMan)
        {
            return Json(Service.Update(SalesMan));
        }
        [HttpDelete]
        public JsonResult<EResponseBase<SalesMan>> DeleteSalesMan(int ID)
        {
            return Json(Service.Delete(ID));
        }
    }
}
