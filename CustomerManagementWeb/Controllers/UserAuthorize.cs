using CustomerManagementWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagementWeb.Controllers
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            LoginClient login = new LoginClient();
            var userCookie = httpContext.Request.Cookies["User"];
            var passCookie = httpContext.Request.Cookies["Pass"];
            if (userCookie != null && passCookie != null && login.CheckLogin(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(passCookie.Value)), userCookie.Value))
            {
                return true;
            }
            httpContext.Response.Redirect("/Home/Login");
            return false;
        }
    }
}