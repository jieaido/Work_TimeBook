using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        [ChildActionOnly]
        public ActionResult BarMenu()
        {
            var m1=new Menubar()
            {
               
           };
           var barmenus=new List<Menubar>()
           {
               new Menubar()
               {
                    MenuId = 1,
                MenusNam = "测1"
               },new Menubar()
               {
                   MenuId = 2,
                MenusNam = "测2",ParentId = 1
                },new Menubar()
               {
                   MenuId = 3,
                MenusNam = "测2"
                },new Menubar()
               {
                   MenuId = 4,
                MenusNam = "测2",ParentId = 3
                },new Menubar()
               {
                   MenuId = 5,
                MenusNam = "测2",
                },new Menubar()
               {
                   MenuId = 6,
                MenusNam = "测2",ParentId = 3
                },new Menubar()
               {
                   MenuId = 7,
                MenusNam = "测2",ParentId = 3
                },new Menubar()
               {
                   MenuId = 8,
                MenusNam = "测2",ParentId = 5
                },new Menubar()
               {
                   MenuId = 9,
                MenusNam = "测2",ParentId = 5
                },
           };

            return PartialView("_BarMenu",barmenus)   ;
        }
    }
}