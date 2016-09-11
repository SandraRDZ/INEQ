using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INEQ.Content;
using INEQ.Models;

namespace INEQ.Controllers
{
    public class StatusController : Controller
    {
        private dbINEQcontext db = new dbINEQcontext();

        // GET: Status
        public ActionResult Index()
        {
            return View(db.Status.ToList());
        }

        // GET: Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statu statu = db.Status.Find(id);
            if (statu == null)
            {
                return HttpNotFound();
            }
            return View(statu);
        }

        // GET: Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Active")] Statu statu)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(statu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statu);
        }

        // GET: Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statu statu = db.Status.Find(id);
            if (statu == null)
            {
                return HttpNotFound();
            }
            return View(statu);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Active")] Statu statu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statu);
        }

        // GET: Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statu statu = db.Status.Find(id);
            if (statu == null)
            {
                return HttpNotFound();
            }
            return View(statu);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statu statu = db.Status.Find(id);
            db.Status.Remove(statu);
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
