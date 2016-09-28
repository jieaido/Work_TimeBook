using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.InterFace;
using Site.Models;

namespace Site.Controllers
{
    public class MenuController : Controller
    {
        private IMenuEntityRepos iMenuEntityRepos;

        public MenuController(IMenuEntityRepos iMenuEntityRepos)
        {
            this.iMenuEntityRepos = iMenuEntityRepos;
        }

        // GET: Menu
        [ChildActionOnly]
        public ActionResult BarMenu()
        {
            var m1=new MenubarViewModel()
            {
               
           };
            var ss = iMenuEntityRepos.ToOrderList(m=>m.ActionName);
            
          
            return PartialView("_BarMenu",ss)   ;
        }
    }
}