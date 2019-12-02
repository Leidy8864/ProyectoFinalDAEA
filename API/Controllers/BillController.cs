using Common.HttpHelpers;
using Domain.CustomModels;
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
    public class BillController : ApiController
    {
        BillService Service;
        public BillController()
        {
            Service = new BillService();
        }
        [HttpGet]
        public JsonResult<EResponseBase<CustomBill>> GetAllBills()
        {
            return Json(Service.Get());
        }
        [HttpGet]
        public JsonResult<EResponseBase<Bill>> GetBill(int ID)
        {
            return Json(Service.GetById(ID));
        }
        [HttpPost]
        public JsonResult<EResponseBase<DataBill>> InsertBill(DataBill dataBill)
        {
            return Json(Service.Add(dataBill));
        }
        [HttpPut]
        public JsonResult<EResponseBase<Bill>> UpdateProduct(Bill order)
        {
            return Json(Service.Update(order));
        }
        [HttpDelete]
        public JsonResult<EResponseBase<Bill>> DeleteBill(int ID)
        {
            return Json(Service.Delete(ID));
        }

        [HttpGet]
        public JsonResult<EResponseBase<CustomBill>> GetByCustomer(String filter)
        {
            return Json(Service.GetByCustomer(filter));
        }

        [HttpGet]
        public JsonResult<EResponseBase<CustomBill>> GetBySalesMan(String filter)
        {
            return Json(Service.GetByCustomer(filter));
        }

        [HttpGet]
        public JsonResult<EResponseBase<CustomBill>> GetByBillID(string filter)
        {
            return Json(Service.GetByBillID(filter));
        }

    }
}
