using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entity;
using Helper;
using Work_TimeBook.Models;


namespace Work_TimeBook.Controllers
{
    public class LoginController : Controller
    {
        private IUserinfoRepos UserinfoRepos;

        public LoginController(IUserinfoRepos userinfoRepos)
        {
            UserinfoRepos = userinfoRepos;
        }

        // GET: Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var ss = Request;
            return View();
        }
        [HttpPost]
        public ActionResult Login(MyLoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {

                int valiteid = UserinfoRepos.ValiteLoginInfo(model.LoginName, model.LoginPwd);
                if (valiteid > 0)
                {
                    FormsAuthenticationTicket tick = new FormsAuthenticationTicket(1,
                    model.LoginName,
                    DateTime.Now,
                    DateTime.Now.AddHours(3.0)
                     , true,
                     "userdata",
                     FormsAuthentication.FormsCookiePath);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(tick));
                    cookie.HttpOnly = true;
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    ModelState.AddModelError("Nologin","请检查账户密码");
                    ViewBag.ReturnUrl = returnUrl;
                    return View(model);
                }


            }

            //FormsAuthentication.SetAuthCookie(name, true);
            return Redirect(returnUrl);

        
            
          
        }
    }
}