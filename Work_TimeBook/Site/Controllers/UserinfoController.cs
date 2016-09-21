using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entity;
using Entity.Model;
using Helper;

namespace Site.Controllers
{
    [Authorize]
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
                //var formsIdentity = User.Identity as FormsIdentity;
                //int id = Convert.ToInt32(formsIdentity.Ticket.UserData);
                int id= UserHelper.GetUserinfoId();
               var userinfo=  iUserinfoRepos.GetUserInfoById(id);
                if (userinfo != null)
                {
                    return View(userinfo);
                }
             
            }
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Edit(int id)
        {
            var result= iUserinfoRepos.GetUserInfoById(id);
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(UserInfo  m)
        {
            if (ModelState.IsValid)
            {
                iUserinfoRepos.AddorUpdate(m);
                iUserinfoRepos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m);
        }
    }
}