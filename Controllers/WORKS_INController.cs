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
    public class WORKS_INController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: WORKS_IN
        public ActionResult Index()
        {
            var wORKS_IN = db.WORKS_IN.Include(w => w.EMPLOYEE).Include(w => w.WORK_CENTER);
            return View(wORKS_IN.ToList());
        }

        // GET: WORKS_IN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKS_IN wORKS_IN = db.WORKS_IN.Find(id);
            if (wORKS_IN == null)
            {
                return HttpNotFound();
            }
            return View(wORKS_IN);
        }

        // GET: WORKS_IN/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name");
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location");
            return View();
        }

        // POST: WORKS_IN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,Work_Center_ID,WORKS_IN_ID")] WORKS_IN wORKS_IN)
        {
            if (ModelState.IsValid)
            {
                db.WORKS_IN.Add(wORKS_IN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", wORKS_IN.Employee_ID);
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location", wORKS_IN.Work_Center_ID);
            return View(wORKS_IN);
        }

        // GET: WORKS_IN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKS_IN wORKS_IN = db.WORKS_IN.Find(id);
            if (wORKS_IN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", wORKS_IN.Employee_ID);
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location", wORKS_IN.Work_Center_ID);
            return View(wORKS_IN);
        }

        // POST: WORKS_IN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,Work_Center_ID,WORKS_IN_ID")] WORKS_IN wORKS_IN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wORKS_IN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", wORKS_IN.Employee_ID);
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location", wORKS_IN.Work_Center_ID);
            return View(wORKS_IN);
        }

        // GET: WORKS_IN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKS_IN wORKS_IN = db.WORKS_IN.Find(id);
            if (wORKS_IN == null)
            {
                return HttpNotFound();
            }
            return View(wORKS_IN);
        }

        // POST: WORKS_IN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WORKS_IN wORKS_IN = db.WORKS_IN.Find(id);
            db.WORKS_IN.Remove(wORKS_IN);
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
