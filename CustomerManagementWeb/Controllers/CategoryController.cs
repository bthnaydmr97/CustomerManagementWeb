using CustomerManagementWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagementWeb.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        [UserAuthorize]
        public ActionResult Index()
        {
            var customer = CategoryClient.GetCategroy().ToList();
            return View(customer);
        }
        [UserAuthorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryDto model)
        {
            var result = CategoryClient.CreateCategory(model);
            return RedirectToAction("Index");
        }
        [UserAuthorize]
        public ActionResult Details(int id)
        {
            var result = CategoryClient.GetCategoryById(id);
            return View(result);
        }
        [UserAuthorize]
        public ActionResult Update(int id)
        {
            var result = CategoryClient.GetCategoryById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Update(CategoryDto categoryDro)
        {
            CategoryClient.UpdateCategory(categoryDro);
            return RedirectToAction("Index");
        }
        [UserAuthorize]
        public ActionResult Delete(int id)
        {
            var result=CategoryClient.DeleteCategory(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}