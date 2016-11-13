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
        private IMenuEntityRepos _iMenuEntityRepos;

        public MenuController(IMenuEntityRepos iMenuEntityRepos)
        {
            this._iMenuEntityRepos = iMenuEntityRepos;
        }

        // GET: Menu
        [ChildActionOnly]
        public ActionResult BarMenu()
        {
            var m1=new MenubarViewModel()
            {
               
           };
            var ss = _iMenuEntityRepos.ToOrderList(m=>m.ActionName).ToList();
            //todo 如果我去掉这个tolist，就会报错误。错误说我执行一个commond时未把一个reader关闭。说明我进行foreach循环的时候依然是从数据库中读取的
            
          
            return PartialView("_BarMenu",ss)   ;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _iMenuEntityRepos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}