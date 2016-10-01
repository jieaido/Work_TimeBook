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
    public class StationEntitiesController : Controller
    {
        private IStationEntityRepos _iStationEntityRepos;
        private ITeamEntityRepos _iTeamEntityRepos;

        public StationEntitiesController(IStationEntityRepos iStationEntityRepos, ITeamEntityRepos iTeamEntityRepos)
        {
            this._iStationEntityRepos = iStationEntityRepos;
            _iTeamEntityRepos = iTeamEntityRepos;
        }


        // GET: StationEntities
        public ActionResult Index()
        {
            return View(_iStationEntityRepos.ToList());
        }

        // GET: StationEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationEntity stationEntity = _iStationEntityRepos.FindById((int) id);
            if (stationEntity == null)
            {
                return HttpNotFound();
            }
            return View(stationEntity);
        }

        // GET: StationEntities/Create
        public ActionResult Create()
        {
            var allTeams = _iStationEntityRepos.GetAllTeams();
           SelectList sl=new SelectList(allTeams, "TeamEntityId", "TeamName");
            ViewBag.sl = sl;
            return View();
        }

        // POST: StationEntities/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StationId,StationName,TeamEntity")] StationEntity stationEntity)
        {
            if (ModelState.IsValid)
            {
                stationEntity.TeamEntity = _iTeamEntityRepos.FindById(stationEntity.TeamEntity.TeamEntityId);
                _iStationEntityRepos.AddorUpdate(stationEntity);
                _iStationEntityRepos.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stationEntity);
        }

        // GET: StationEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationEntity stationEntity = _iStationEntityRepos.FindById(id);
            if (stationEntity == null)
            {
                return HttpNotFound();
            }
            return View(stationEntity);
        }

        // POST: StationEntities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StationId,StationName,Derscpion")] StationEntity stationEntity)
        {
            if (ModelState.IsValid)
            {
                _iStationEntityRepos.AddorUpdate(stationEntity);
                _iStationEntityRepos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stationEntity);
        }

        // GET: StationEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationEntity stationEntity = _iStationEntityRepos.FindById(id);
            if (stationEntity == null)
            {
                return HttpNotFound();
            }
            return View(stationEntity);
        }

        // POST: StationEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationEntity stationEntity = _iStationEntityRepos.FindById(id);
            _iStationEntityRepos.Delete(stationEntity);
            _iStationEntityRepos.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _iStationEntityRepos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
