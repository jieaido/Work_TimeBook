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
    public class TeamEntitiesController : Controller
    {
        

        private ITeamEntityRepos IteamEntityRepos;

        public TeamEntitiesController(ITeamEntityRepos iteamEntityRepos)
        {
            IteamEntityRepos = iteamEntityRepos;
        }

        // GET: TeamEntities
        public ActionResult Index()
        {
            return View(IteamEntityRepos.ToList());
        }

        // GET: TeamEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamEntity teamEntity = IteamEntityRepos.FindById((int) id);
            if (teamEntity == null)
            {
                return HttpNotFound();
            }
            return View(teamEntity);
        }

        // GET: TeamEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamEntities/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamEntityId,TeamName")] TeamEntity teamEntity)
        {
            if (ModelState.IsValid)
            {
                var sss= IteamEntityRepos.GetEntityState(teamEntity);
                IteamEntityRepos.AddorUpdate(teamEntity);
                IteamEntityRepos.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamEntity);
        }

        // GET: TeamEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamEntity teamEntity = IteamEntityRepos.FindById((int)id);
            if (teamEntity == null)
            {
                return HttpNotFound();
            }
            return View(teamEntity);
        }

        // POST: TeamEntities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamEntityId,TeamName")] TeamEntity teamEntity)
        {
            if (ModelState.IsValid)
            {
                var sss = IteamEntityRepos.GetEntityState(teamEntity);
                IteamEntityRepos.AddorUpdate(teamEntity);
                IteamEntityRepos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamEntity);
        }

        // GET: TeamEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamEntity teamEntity = IteamEntityRepos.FindById((int) id);
            if (teamEntity == null)
            {
                return HttpNotFound();
            }
            return View(teamEntity);
        }

        // POST: TeamEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamEntity teamEntity = IteamEntityRepos.FindById((int)id);
        IteamEntityRepos.Delete(teamEntity);
            IteamEntityRepos.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                IteamEntityRepos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
