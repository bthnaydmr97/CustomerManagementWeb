using CustomerManagementWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagementWeb.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Customer
        [UserAuthorize]
        public ActionResult Index()
        {
            var customer = CustomerClient.GetCustomer().ToList();
            return View(customer);
        }
        [UserAuthorize]
        public ActionResult Create()
        {  
            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomerDto model)
        {
            var result = CustomerClient.CreateCustomer(model);
            return RedirectToAction("Index");
        }
        [UserAuthorize]
        public ActionResult Details(int id)
        {
            var result = CustomerClient.GetCustomerById(id);
            return View(result);
        }
        [UserAuthorize]
        public ActionResult Update(int id)
        {
            var result = CustomerClient.GetCustomerById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Update(CustomerDto customerDto)
        {
            CustomerClient.UpdateCustomer(customerDto);
            return RedirectToAction("Index");
        }
        [UserAuthorize]
        public ActionResult Delete(int id)
        {
            CustomerClient.DeleteCustomer(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult OrderHistory(int id)
        {
            var result=CustomerClient.GetOrderHistoryById(id);
            return View(result);
        }




    }
}