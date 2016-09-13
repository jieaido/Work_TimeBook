using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity;
using Entity.Model;

namespace Work_TimeBook.Controllers
{
    public class PermissesController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Permisses
        public ActionResult Index()
        {
            return View(db.Permisses.ToList());
        }

        // GET: Permisses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiss permiss = db.Permisses.Find(id);
            if (permiss == null)
            {
                return HttpNotFound();
            }
            return View(permiss);
        }

        // GET: Permisses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permisses/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissId,PermissName,ControllerName,ActionName")] Permiss permiss)
        {
            if (ModelState.IsValid)
            {
                db.Permisses.Add(permiss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(permiss);
        }

        // GET: Permisses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiss permiss = db.Permisses.Find(id);
            if (permiss == null)
            {
                return HttpNotFound();
            }
            return View(permiss);
        }

        // POST: Permisses/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissId,PermissName,ControllerName,ActionName")] Permiss permiss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permiss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(permiss);
        }

        // GET: Permisses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiss permiss = db.Permisses.Find(id);
            if (permiss == null)
            {
                return HttpNotFound();
            }
            return View(permiss);
        }

        // POST: Permisses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permiss permiss = db.Permisses.Find(id);
            db.Permisses.Remove(permiss);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
