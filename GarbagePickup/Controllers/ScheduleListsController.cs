using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarbagePickup.Models;

namespace GarbagePickup.Controllers
{
    public class ScheduleListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScheduleLists
        public ActionResult Index()
        {
            return View(db.ScheduleLists.ToList());
        }

        // GET: ScheduleLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleList scheduleList = db.ScheduleLists.Find(id);
            if (scheduleList == null)
            {
                return HttpNotFound();
            }
            return View(scheduleList);
        }

        // GET: ScheduleLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduleLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date")] ScheduleList scheduleList)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleLists.Add(scheduleList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scheduleList);
        }

        // GET: ScheduleLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleList scheduleList = db.ScheduleLists.Find(id);
            if (scheduleList == null)
            {
                return HttpNotFound();
            }
            return View(scheduleList);
        }

        // POST: ScheduleLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date")] ScheduleList scheduleList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduleList);
        }

        // GET: ScheduleLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleList scheduleList = db.ScheduleLists.Find(id);
            if (scheduleList == null)
            {
                return HttpNotFound();
            }
            return View(scheduleList);
        }

        // POST: ScheduleLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleList scheduleList = db.ScheduleLists.Find(id);
            db.ScheduleLists.Remove(scheduleList);
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
