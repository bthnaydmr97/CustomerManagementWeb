using CustomerManagementWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagementWeb.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        [UserAuthorize]
        public ActionResult Index()
        {
            var product = ProductClient.GetProduct().ToList();
            return View(product);
        }
        [UserAuthorize]
        public ActionResult Create()
        {
            var categories = CategoryClient.GetCategroy().ToList();
            var categoriesSelectListData = new List<SelectListItem>();

            foreach (var item in categories)
            {
                categoriesSelectListData.Add(new SelectListItem { Text = item.CategoryName, Value = item.Id.ToString() });
            }
            ViewBag.Categories = categoriesSelectListData;
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductDto model)
        {
            ProductClient.CreateProduct(model);
            return RedirectToAction("Index");
        }
        [UserAuthorize]
        public ActionResult Details(int id)
        {
            var result = ProductClient.GetProductById(id);
            return View(result);
        }
        [UserAuthorize]
        public ActionResult Update(int id)
        {
            var result = ProductClient.GetProductById(id);
            var categories = CategoryClient.GetCategroy().ToList();
            var categoriesSelectListData = new List<SelectListItem>();

            foreach (var item in categories)
            {
                categoriesSelectListData.Add(new SelectListItem { Text = item.CategoryName, Value = item.Id.ToString() });
            }
            ViewBag.Categories = categoriesSelectListData;
            return View(result);
        }
        [HttpPost]
        public ActionResult Update(ProductDto productDto)
        {
            ProductClient.UpdateProduct(productDto);
            return RedirectToAction("Index");
        }
        [UserAuthorize]
        public ActionResult Delete(int id)
        {
            ProductClient.DeleteProduct(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}