using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index(int id)
        {
            var userinfo = iUserinfoRepos.GetUserInfoById(id);
            if (userinfo!=null)
            {
                return View(userinfo);
            }
            return RedirectToAction("Login", "Login");
        }
    }
}