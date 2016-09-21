using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entity;

namespace Site.Controllers
{
    public class UserinfoController : Controller
    {
        private IUserinfoRepos iUserinfoRepos;

        public UserinfoController(IUserinfoRepos iUserinfoRepos)
        {
            this.iUserinfoRepos = iUserinfoRepos;
        }

        // GET: Userinfo
        public ActionResult Index()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                var formsIdentity = User.Identity as FormsIdentity;
                int id = Convert.ToInt32(formsIdentity.Ticket.UserData);
               var userinfo=  iUserinfoRepos.GetUserInfoById(id);
                if (userinfo != null)
                {
                    return View(userinfo);
                }
             
            }
            return RedirectToAction("Login", "Login");
        }
    }
}