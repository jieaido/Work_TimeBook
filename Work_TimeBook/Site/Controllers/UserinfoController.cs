using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Entity;
using Entity.Model;
using Helper;
using Site.Models;

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
            var userinfo= iUserinfoRepos.GetUserInfoById(id);
            var  result=Mapper.Map<UserInfoEditViewModel>(userinfo);
            return View(result);

        }
        [HttpPost]
        public ActionResult Edit(UserInfoEditViewModel  model)
        {
            if (ModelState.IsValid)
            {
                var result = iUserinfoRepos.FindById(model.UserInfoEntityId);
                result = Mapper.Map(model, result);
              iUserinfoRepos.AddorUpdate(result);
                iUserinfoRepos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult ChangePassWord(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = iUserinfoRepos.FindById((int)id);
            var result = new UserinfoChangePwdViewModel()
            {
                UserInfoEntityId = model.UserInfoEntityId
            };
            
            return View(result);
        }

        [HttpPost]
        public ActionResult ChangePassWord(UserinfoChangePwdViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var userinfo = iUserinfoRepos.FindById(model.UserInfoEntityId);
                if (userinfo.LoginPwd == model.OldPwd)
                {
                    var result = Mapper.Map(model, userinfo);
                    iUserinfoRepos.AddorUpdate(result);
                    iUserinfoRepos.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                   ModelState.AddModelError("msg","请检查原密码！");
                }
                
            }
            return View(model);
        }
       
    }
}