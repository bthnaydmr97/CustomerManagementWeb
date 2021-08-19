using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace CustomerManagementWeb.Controllers
{
    public class HomeController : BaseController
    {
        [UserAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string pass,string user)
        {
            if (!LoginClient.CheckLogin(pass,user))
            {
                ViewData["error"] = "Yanlış kullanıcı adı veya şifre";
                return View();
            }
            var userCookie = new HttpCookie("User") { Value = user, Expires = DateTime.Now.AddMinutes(1200) };
            pass = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(pass));
            var passCookie = new HttpCookie("Pass") { Value = pass, Expires = DateTime.Now.AddMinutes(1200) };
            Response.Cookies.Add(userCookie);
            Response.Cookies.Add(passCookie);
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            var userCookie = Response.Cookies["User"];
            var passCookie = Response.Cookies["Pass"];
            userCookie.Value = null;
            passCookie.Value = null;
            return RedirectToAction("Login");
        }

       


    }
}