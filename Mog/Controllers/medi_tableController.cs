using Mog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mog.Controllers
{
    public class medi_tableController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: medi_table
        public ActionResult Index()
        {
            return View(db.medi_table.ToList());
        }

        // GET: medi_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medi_table medi_table = db.medi_table.Find(id);
            if (medi_table == null)
            {
                return HttpNotFound();
            }
            return View(medi_table);
        }

        // GET: medi_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: medi_table/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Category,Description,Disease,Quantity")] medi_table medi_table)
        {
            if (ModelState.IsValid)
            {
                db.medi_table.Add(medi_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medi_table);
        }

        // GET: medi_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medi_table medi_table = db.medi_table.Find(id);
            if (medi_table == null)
            {
                return HttpNotFound();
            }
            return View(medi_table);
        }

        // POST: medi_table/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Category,Description,Disease,Quantity")] medi_table medi_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medi_table).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medi_table);
        }

        // GET: medi_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medi_table medi_table = db.medi_table.Find(id);
            if (medi_table == null)
            {
                return HttpNotFound();
            }
            return View(medi_table);
        }

        // POST: medi_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            medi_table medi_table = db.medi_table.Find(id);
            db.medi_table.Remove(medi_table);
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