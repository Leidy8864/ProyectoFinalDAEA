using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
using WEB.Proxy;
namespace WEB.Controllers
{
    public class CustomerController : Controller
    {

        CustomerProxy proxy = new CustomerProxy();
        // GET: Customer

        public ActionResult IndexRazor()
        {
            var response = Task.Run(() => proxy.GetCustomersAsync());
            return View(response.Result.List);
        }
        public ActionResult IndexTarea()
        {
            var response = Task.Run(() => proxy.GetCustomersAsync());
            return View(response.Result.List);
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getCustomer(string id)
        {
            var response = Task.Run(() => proxy.GetCustomersAsync());
            return Json(response.Result.List, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CustomerDetail(int id)
        {
            var response = Task.Run(() => proxy.DetailCustomerAsync(id));
            return Json(response.Result.Object, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult createCustomer(CustomerModel Customer)
        {
            var response = Task.Run(() => proxy.InsertAsync(Customer));
            string message = response.Result.Message;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult updateCustomer(CustomerModel Customer)
        {
            var response = Task.Run(() => proxy.UpdateAsync(Customer));
            string message = response.Result.Message;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult deleteCustomer(int id)
        {
            var response = Task.Run(() => proxy.DeleteCustomerAsync(id));
            string message = response.Result.Message;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult searchCustomers(string query)
        {
            var response = Task.Run(() => proxy.SearchCustomersAsync(query));
            string message = response.Result.Message;
            return Json(response.Result.List, JsonRequestBehavior.AllowGet);
        }
    }

}