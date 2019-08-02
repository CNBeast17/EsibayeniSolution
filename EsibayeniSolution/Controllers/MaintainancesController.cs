using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EsibayeniSolution.Models;
using Microsoft.AspNet.Identity;

namespace EsibayeniSolution.Controllers
{
    public class MaintainancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Maintainances
        public ActionResult Index()
        {
            var maintainances = db.Maintainances.Include(m => m.LivesStock).Include(m => m.MaintainanceProcess).Include(m => m.MaitainanceStock);
            return View(maintainances.ToList());
        }

        // GET: Maintainances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainance maintainance = db.Maintainances.Find(id);
            if (maintainance == null)
            {
                return HttpNotFound();
            }
            return View(maintainance);
        }

        // GET: Maintainances/Create
        public ActionResult Create()
        {
            ViewBag.LivestockID = new SelectList(db.LivesStocks, "LivestockID", "Code");
            ViewBag.MainPId = new SelectList(db.MaintainanceProcesses, "MainPId", "MainName");
            ViewBag.ProductId = new SelectList(db.MaintainanceStocks, "ProductID", "ProductName");
            return View();
        }

        // POST: Maintainances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MProcID,LivestockID,ProductId,ProductCategory,MainPId,CurrentWeight")] Maintainance maintainance)
        {
            if (ModelState.IsValid)
            {
                LivesStock livestock = db.LivesStocks.Find(maintainance.LivestockID);
                maintainance.User = User.Identity.GetUserName();
                maintainance.AttendanceDate = maintainance.DateTimeNow();
                maintainance.PreviousDate = maintainance.DateTimeNow();
                maintainance.PreviousWeight = livestock.Weight;
                db.Maintainances.Add(maintainance);
                livestock.Weight = maintainance.CurrentWeight;
                db.Entry(livestock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivestockID = new SelectList(db.LivesStocks, "LivestockID", "Code", maintainance.LivestockID);
            ViewBag.MainPId = new SelectList(db.MaintainanceProcesses, "MainPId", "MainName", maintainance.MainPId);
            ViewBag.ProductId = new SelectList(db.MaintainanceStocks, "ProductID", "ProductName", maintainance.ProductId);
            return View(maintainance);
        }

        // GET: Maintainances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainance maintainance = db.Maintainances.Find(id);
            if (maintainance == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivestockID = new SelectList(db.LivesStocks, "LivestockID", "Code", maintainance.LivestockID);
            ViewBag.MainPId = new SelectList(db.MaintainanceProcesses, "MainPId", "MainName", maintainance.MainPId);
            ViewBag.ProductId = new SelectList(db.MaintainanceStocks, "ProductID", "ProductName", maintainance.ProductId);
            return View(maintainance);
        }

        // POST: Maintainances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MProcID,User,LivestockID,ProductId,ProductCategory,MainPId,AttendanceDate,PreviousDate,PreviousWeight,CurrentWeight")] Maintainance maintainance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintainance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivestockID = new SelectList(db.LivesStocks, "LivestockID", "Code", maintainance.LivestockID);
            ViewBag.MainPId = new SelectList(db.MaintainanceProcesses, "MainPId", "MainName", maintainance.MainPId);
            ViewBag.ProductId = new SelectList(db.MaintainanceStocks, "ProductID", "ProductName", maintainance.ProductId);
            return View(maintainance);
        }

        // GET: Maintainances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainance maintainance = db.Maintainances.Find(id);
            if (maintainance == null)
            {
                return HttpNotFound();
            }
            return View(maintainance);
        }

        // POST: Maintainances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maintainance maintainance = db.Maintainances.Find(id);
            db.Maintainances.Remove(maintainance);
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
