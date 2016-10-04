using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class WorkTimeEntitiesController : Controller
    {
        private EFDbContext db = new EFDbContext();
        private IWorkTimeRepos _workTimeRepos;
        private IStationEntityRepos _iStationEntityRepos;
        private ITeamEntityRepos _iTeamEntityRepos;

        public WorkTimeEntitiesController(IWorkTimeRepos workTimeRepos, IStationEntityRepos iStationEntityRepos, ITeamEntityRepos iTeamEntityRepos)
        {
            _workTimeRepos = workTimeRepos;
            _iStationEntityRepos = iStationEntityRepos;
            _iTeamEntityRepos = iTeamEntityRepos;
        }

        // GET: WorkTimeEntities
        public ActionResult Index()
        {
            return View(db.WorkTimeEntities.ToList());
        }

        // GET: WorkTimeEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTimeEntity workTimeEntity = db.WorkTimeEntities.Find(id);
            if (workTimeEntity == null)
            {
                return HttpNotFound();
            }
            return View(workTimeEntity);
        }

       // GET: WorkTimeEntities/Create
        public ActionResult Create()
        {
            var result = GetSelectListItems();
            WorkTimeViewModel vm = new WorkTimeViewModel()
            {
                SelectStationid = result
            };
            return View(vm);
            //foreach (var stationEntity in teamEntity.StationEntity)
            //{
            //    var ss = new SelectListItem()
            //    {
            //        Group = new SelectListGroup()
            //        {
            //            Name = teamEntity.TeamName
            //        },
            //        Text = stationEntity.StationName,
            //        Value = stationEntity.StationId.ToString()
            //    };
            //    result.Add(ss);
            
        }

        private List<SelectListItem> GetSelectListItems()
        {
            var re = _iStationEntityRepos.GetAllTeams();
            var result = (from teamEntity in re
                from stationEntity in teamEntity.StationEntities
                select new SelectListItem()
                {
                    Group = new SelectListGroup()
                    {
                        Name = teamEntity.TeamName
                    },
                    Text = stationEntity.StationName,
                    Value = stationEntity.StationId.ToString()
                }).ToList();
            return result;
        }

        // POST: WorkTimeEntities/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkTimeViewModel model)
        {
            if (ModelState.IsValid)
            {
              
            
               //WorkTimeEntity wt=new WorkTimeEntity()
               //{
               //     Remarks = model.Remarks,
               //    // StationEntityId = model.StationEntityIds,
               //    // StationEntity = _iStationEntityRepos.FindById(model.StationEntityIds),
               //    //TeamEntityId = _iStationEntityRepos.FindById(model.StationEntityIds).TeamEntityId,
               //    WtContent=model.WtContent,
               //    WtStartDateTime = model.WtStartDateTime,
               //    WtOverDateTime = model.WtOverDateTime,
               //    WtValue = model.WtValue

               //  };
                var wt = EntityMapper.GetEntity<WorkTimeEntity, WorkTimeViewModel>(model);
                wt.StationEntities = _iStationEntityRepos.FindById(model.StationEntityIds);
                _workTimeRepos.add(wt);
                //db.WorkTimeEntities.Add(workTimeEntity);
                 int i=_workTimeRepos.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: WorkTimeEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTimeEntity workTimeEntity = db.WorkTimeEntities.Find(id);
            if (workTimeEntity == null)
            {
                return HttpNotFound();
            }
            WorkTimeViewModel model = EntityMapper.GetEntity<WorkTimeViewModel, WorkTimeEntity>(workTimeEntity);
            model.SelectStationid = GetSelectListItems();
            return View(model);
        }

        // POST: WorkTimeEntities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( WorkTimeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _workTimeRepos.FindById(model.WorkTimeId);
                Mapper.Map(model, result);
                result.StationEntities = _iStationEntityRepos.FindById(model.StationEntityIds);
                //_workTimeRepos.SetModified(result);
                _workTimeRepos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: WorkTimeEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTimeEntity workTimeEntity = db.WorkTimeEntities.Find(id);
            if (workTimeEntity == null)
            {
                return HttpNotFound();
            }
            return View(workTimeEntity);
        }

        // POST: WorkTimeEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkTimeEntity workTimeEntity = db.WorkTimeEntities.Find(id);
            db.WorkTimeEntities.Remove(workTimeEntity);
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
