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
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MyLoginViewModel model,string returnurl)
        {
            //var userinfoid= UserinfoRepos.ValiteLoginInfo(model.LoginName, model.LoginPwd);
            //if (userinfoid>0)
            //{
            //    var userinfo = UserinfoRepos.UserInfos.FirstOrDefault(u => u.UserInfoId == userinfoid);
            //    if (userinfo!=null)
            //    {
            //        Session[Keys.LoginUser] = userinfo;
                    
            //        return Redirect(returnurl);
            //    }
                FormsAuthenticationTicket tick=new FormsAuthenticationTicket(1,
                    model.LoginName,
                    DateTime.Now,
                    DateTime.Now.AddHours(3.0)
                    ,true,
                    "userdata",
                    FormsAuthentication.FormsCookiePath);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(tick));
            cookie.HttpOnly = true;
            HttpContext.Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
            

        
            
          
        }
    }
}