using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity;
using Entity.InterFace;
using Entity.Model;

namespace Site.Controllers
{
    public class MenuEntitiesController : Controller
    {
        private  IMenuEntityRepos _iMenuEntityRepos;

        public MenuEntitiesController(IMenuEntityRepos iMenuEntityRepos)
        {
            this._iMenuEntityRepos = iMenuEntityRepos;
        }

        // GET: MenuEntities
        public ActionResult Index()
        {
            return View(_iMenuEntityRepos.GetSet().ToList());
        }

        // GET: MenuEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuEntity menuEntity = _iMenuEntityRepos.GetSet().Find(id);
            if (menuEntity == null)
            {
                return HttpNotFound();
            }
            return View(menuEntity);
        }

        // GET: MenuEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuEntities/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuEntityId,ParentMenuId,MenuName,MenuDisplayName,ControllerName,ActionName,SortId")] MenuEntity menuEntity)
        {
            if (ModelState.IsValid)
            {
                _iMenuEntityRepos.GetSet().Add(menuEntity);
                _iMenuEntityRepos.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuEntity);
        }

        // GET: MenuEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuEntity menuEntity = _iMenuEntityRepos.GetSet().Find(id);
            if (menuEntity == null)
            {
                return HttpNotFound();
            }
            var ss=new List<SelectListItem>();
            var result = from s in _iMenuEntityRepos.GetAllRootMenus()
                select new SelectListItem()
                {
                    Text = s.MenuDisplayName,
                    Value = s.MenuEntityId.ToString()
                };
            ss.Add(new SelectListItem()
            {
                Text = "根菜单",
                Value = "-1"
                
            });
             ss.AddRange(result);
            ViewBag.parentid= ss;
            return View(menuEntity);
        }

        // POST: MenuEntities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuEntityId,ParentMenuId,MenuName,MenuDisplayName,ControllerName,ActionName,SortId")] MenuEntity menuEntity)
        {
            if (ModelState.IsValid)
            {
                _iMenuEntityRepos.AddorUpdate(menuEntity);
                _iMenuEntityRepos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuEntity);
        }

        // GET: MenuEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuEntity menuEntity = _iMenuEntityRepos.GetSet().Find(id);
            if (menuEntity == null)
            {
                return HttpNotFound();
            }
            return View(menuEntity);
        }

        // POST: MenuEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuEntity menuEntity = _iMenuEntityRepos.GetSet().Find(id);
            _iMenuEntityRepos.GetSet().Remove(menuEntity);
            _iMenuEntityRepos.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               _iMenuEntityRepos.GetContext().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
