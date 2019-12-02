using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class BillController : Controller
    {
        Proxy.BillProxy proxy = new Proxy.BillProxy();

        // GET: Bill
        public ActionResult Index()
        {
            var response = Task.Run(() => proxy.GetBillsAsync());
            return View(response.Result.List);
        }
        public JsonResult GetBills(string id)
        {
            var response = Task.Run(() => proxy.GetBillsAsync());
            return Json(response.Result.List, JsonRequestBehavior.AllowGet);
        }
        // GET: Bill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bill/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bill/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
