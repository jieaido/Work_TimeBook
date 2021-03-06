﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entity;
using Entity.InterFace;
using Entity.Model;
using Helper;
using Microsoft.AspNet.Identity;
using Work_TimeBook.Models;


namespace Work_TimeBook.Controllers
{
    public class LoginController : Controller
    {
        private IUserinfoRepos _userinfoRepos;
        private IStationEntityRepos _iStationEntityRepos;
        private ITeamEntityRepos _iTeamEntityRepos;

        public LoginController(IUserinfoRepos userinfoRepos, IStationEntityRepos iStationEntityRepos, ITeamEntityRepos iTeamEntityRepos)
        {
            _userinfoRepos = userinfoRepos;
            _iStationEntityRepos = iStationEntityRepos;
            _iTeamEntityRepos = iTeamEntityRepos;
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
                int valiteid = _userinfoRepos.ValiteLoginInfo(model.LoginName, model.LoginPwd);

                if (valiteid > 0)
                {
                    DateTime exprierTime=model.RememberMe==true?DateTime.Now.AddHours(3):
                    DateTime.Now.AddDays(3); 
                    FormsAuthenticationTicket tick = new FormsAuthenticationTicket(1,
                    model.LoginName,
                    DateTime.Now,
                    //这个是票据的过期时间
                    exprierTime
                     , true,
                     valiteid.ToString(),
                     FormsAuthentication.FormsCookiePath);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(tick));
                    cookie.HttpOnly = true;
                    //todo 这个是设置cookie的过期时间
                    cookie.Expires = DateTime.Now.AddDays(3);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    //todo 添加模型错误
                    ModelState.AddModelError("Nologin","请检查账户密码");
                    ViewBag.ReturnUrl = returnUrl;
                    return View(model);
                }
                
            }
            if (string.IsNullOrEmpty(returnUrl ))
            {
                return RedirectToAction("index", "Home");
            }
            
            return Redirect(returnUrl);

        
            
          
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Home");
        }
        
        public ActionResult Register()
        {
            SelectList sl = new SelectList(_iStationEntityRepos.GetAllTeams(), "TeamEntityId", "TeamName");
            ViewBag.sl = sl;
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserInfoEntity userInfoEntity = new UserInfoEntity()
                {
                    LoginName = model.UserName,
                    LoginPwd = model.Password,
                    Team = _iTeamEntityRepos.FindById(model.TeamId),
                    RealName = model.RealName
                   
                    
                };
                _userinfoRepos.AddorUpdate(userInfoEntity);
                _userinfoRepos.SaveChanges();
                return View("Login");
            }

            return View();
        }

        public JsonResult ValiteUserName(string UserName)
        {
            if (!_userinfoRepos.ExistUserName(UserName))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json("用户名已存在，请更换用户名",JsonRequestBehavior.AllowGet);
        }
    }
}