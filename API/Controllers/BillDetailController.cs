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
    public class BillDetailController : ApiController
    {
        BillDetailService Service;
        public BillDetailController()
        {
            Service = new BillDetailService();
        }
        [HttpGet]
        public JsonResult<EResponseBase<BillDetail>> GetAllBillDetails()
        {
            return Json(Service.Get());
        }
        [HttpGet]
        public JsonResult<EResponseBase<BillDetail>> GetBillDetail(int ID)
        {
            return Json(Service.GetById(ID));
        }
        [HttpPost]
        public JsonResult<EResponseBase<BillDetail>> InsertBillDetail(BillDetail BillDetail)
        {
            return Json(Service.Add(BillDetail));
        }
        [HttpPut]
        public JsonResult<EResponseBase<BillDetail>> UpdateBillDetail(BillDetail BillDetail)
        {
            return Json(Service.Update(BillDetail));
        }
        [HttpDelete]
        public JsonResult<EResponseBase<BillDetail>> DeleteBillDetail(int ID)
        {
            return Json(Service.Delete(ID));
        }
    }
}
