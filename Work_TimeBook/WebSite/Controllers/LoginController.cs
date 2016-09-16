using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebSite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name)
        {
            FormsAuthenticationTicket tick = new FormsAuthenticationTicket(1,
                    "Name",
                   DateTime.Now,
                    DateTime.Now.AddHours(3.0),
                    true,
                    "userdata",
                    FormsAuthentication.FormsCookiePath);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(tick));
            cookie.HttpOnly = true;
            HttpContext.Response.Cookies.Add(cookie);
            //FormsAuthentication.SetAuthCookie(name, true);
            return RedirectToAction("Index", "Home");
        }
    }
}