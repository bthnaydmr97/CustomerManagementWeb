using CustomerManagementWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagementWeb.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Order
        [UserAuthorize]
        public ActionResult Index()
        {
            var order = OrderClient.GetOrder().ToList();
            return View(order);
        }
        [UserAuthorize]
        public ActionResult Create()
        {
            var products = ProductClient.GetProduct().ToList();
            var productsSelectListData = new List<SelectListItem>();

            foreach (var item in products)
            {
                productsSelectListData.Add(new SelectListItem { Text = item.ProductName, Value = item.Id.ToString() });
            }
            ViewBag.Products = productsSelectListData;

            var customers = CustomerClient.GetCustomer().ToList();
            var customersSelectListData = new List<SelectListItem>();

            foreach (var item in customers)
            {
                customersSelectListData.Add(new SelectListItem { Text = item.Name + item.Surname, Value = item.Id.ToString() });
            }
            ViewBag.Customers = customersSelectListData;

            var payments = PaymentClient.GetPayment().ToList();
            var paymentsSelectListData = new List<SelectListItem>();

            foreach (var item in payments)
            {
                paymentsSelectListData.Add(new SelectListItem { Text = item.PaymentType, Value = item.Id.ToString() });
            }
            ViewBag.Payments = paymentsSelectListData;

            return View();
        }
        [HttpPost]
        public ActionResult Create(OrderDto model)
        {
            var result =OrderClient.CreateOrder(model);
            return RedirectToAction("Index");
        }
        [UserAuthorize]
        public ActionResult Details(int id)
        {
            var result = OrderClient.GetOrderById(id);
            return View(result);
        }
        [UserAuthorize]
        public ActionResult Delete(int id)
        {
            OrderClient.DeleteOrder(id);
            return Redirect(Request.UrlReferrer.ToString());
        }


    }
}