using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEProject.Models;

namespace SEProject.Controllers
{
    public class SUPERVISORsController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: SUPERVISORs
        public ActionResult Index()
        {
            return View(db.SUPERVISOR.ToList());
        }

        // GET: SUPERVISORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPERVISOR sUPERVISOR = db.SUPERVISOR.Find(id);
            if (sUPERVISOR == null)
            {
                return HttpNotFound();
            }
            return View(sUPERVISOR);
        }

        // GET: SUPERVISORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUPERVISORs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Supervisor_ID")] SUPERVISOR sUPERVISOR)
        {
            if (ModelState.IsValid)
            {
                db.SUPERVISOR.Add(sUPERVISOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sUPERVISOR);
        }

        // GET: SUPERVISORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPERVISOR sUPERVISOR = db.SUPERVISOR.Find(id);
            if (sUPERVISOR == null)
            {
                return HttpNotFound();
            }
            return View(sUPERVISOR);
        }

        // POST: SUPERVISORs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Supervisor_ID")] SUPERVISOR sUPERVISOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUPERVISOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sUPERVISOR);
        }

        // GET: SUPERVISORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPERVISOR sUPERVISOR = db.SUPERVISOR.Find(id);
            if (sUPERVISOR == null)
            {
                return HttpNotFound();
            }
            return View(sUPERVISOR);
        }

        // POST: SUPERVISORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUPERVISOR sUPERVISOR = db.SUPERVISOR.Find(id);
            db.SUPERVISOR.Remove(sUPERVISOR);
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
