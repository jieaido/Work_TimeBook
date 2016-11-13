﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Entity;
using Entity.InterFace;
using Entity.Model;
using Site.Map;
using Site.Models;

namespace Site.Controllers
{
    public class StationEntitiesController : Controller
    {
        private IStationEntityRepos _iStationEntityRepos;
        private ITeamEntityRepos _iTeamEntityRepos;

        public StationEntitiesController(IStationEntityRepos iStationEntityRepos, ITeamEntityRepos iTeamEntityRepos)
        {
            this._iStationEntityRepos = iStationEntityRepos;
            this._iTeamEntityRepos = iTeamEntityRepos;
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
            GetTeamValueAndSetViewBag();
            return View();
        }
        /// <summary>
        /// 获取team生成selectlist
        /// </summary>
        private void GetTeamValueAndSetViewBag()
        {
            var allTeams = _iStationEntityRepos.GetAllTeams();
            SelectList sl = new SelectList(allTeams, "TeamEntityId", "TeamName");
            ViewBag.sl = sl;
        }

        // POST: StationEntities/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StationEntity stationEntity)
        {
            if (ModelState.IsValid)
            {
                stationEntity.TeamEntities = _iTeamEntityRepos.FindById(stationEntity.TeamEntities.TeamEntityId);
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
          //  var result = EntityMapper.GetStationViewModelByEntity(stationEntity);
            var result = EntityMapper.GetEntity<StationViewModel, StationEntity>(stationEntity);
            result.TeamEntityId = stationEntity.TeamEntities.TeamEntityId;
            GetTeamValueAndSetViewBag();
            return View(result);
        }

        // POST: StationEntities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _iStationEntityRepos.FindById(model.StationId);
               
                Mapper.Map(model, result);
                result.TeamEntities = _iTeamEntityRepos.FindById(model.TeamEntityId);
                _iStationEntityRepos.SetModified(result);
                _iStationEntityRepos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
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
