using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EsibayeniSolution.Models;

namespace EsibayeniSolution.Controllers
{
    public class MaintainanceProcessesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MaintainanceProcesses
        public ActionResult Index()
        {
            var maintainanceProcesses = db.MaintainanceProcesses.Include(m => m.LivesStock);
            return View(maintainanceProcesses.ToList());
        }

        // GET: MaintainanceProcesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintainanceProcess maintainanceProcess = db.MaintainanceProcesses.Find(id);
            if (maintainanceProcess == null)
            {
                return HttpNotFound();
            }
            return View(maintainanceProcess);
        }

        // GET: MaintainanceProcesses/Create
        public ActionResult Create()
        {
            ViewBag.LivestockID = new SelectList(db.LivesStocks, "LivestockID", "Code");
            return View();
        }

        // POST: MaintainanceProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MProcID,LivestockID,date,time")] MaintainanceProcess maintainanceProcess)
        {
            if (ModelState.IsValid)
            {
                db.MaintainanceProcesses.Add(maintainanceProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivestockID = new SelectList(db.LivesStocks, "LivestockID", "Code", maintainanceProcess.LivestockID);
            return View(maintainanceProcess);
        }

        // GET: MaintainanceProcesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintainanceProcess maintainanceProcess = db.MaintainanceProcesses.Find(id);
            if (maintainanceProcess == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivestockID = new SelectList(db.LivesStocks, "LivestockID", "Code", maintainanceProcess.LivestockID);
            return View(maintainanceProcess);
        }

        // POST: MaintainanceProcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MProcID,LivestockID,date,time")] MaintainanceProcess maintainanceProcess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintainanceProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivestockID = new SelectList(db.LivesStocks, "LivestockID", "Code", maintainanceProcess.LivestockID);
            return View(maintainanceProcess);
        }

        // GET: MaintainanceProcesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintainanceProcess maintainanceProcess = db.MaintainanceProcesses.Find(id);
            if (maintainanceProcess == null)
            {
                return HttpNotFound();
            }
            return View(maintainanceProcess);
        }

        // POST: MaintainanceProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintainanceProcess maintainanceProcess = db.MaintainanceProcesses.Find(id);
            db.MaintainanceProcesses.Remove(maintainanceProcess);
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
