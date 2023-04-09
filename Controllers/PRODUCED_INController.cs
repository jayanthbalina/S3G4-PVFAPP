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
    public class PRODUCED_INController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: PRODUCED_IN
        public ActionResult Index()
        {
            var pRODUCED_IN = db.PRODUCED_IN.Include(p => p.PRODUCT).Include(p => p.WORK_CENTER);
            return View(pRODUCED_IN.ToList());
        }

        // GET: PRODUCED_IN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCED_IN pRODUCED_IN = db.PRODUCED_IN.Find(id);
            if (pRODUCED_IN == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCED_IN);
        }

        // GET: PRODUCED_IN/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description");
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location");
            return View();
        }

        // POST: PRODUCED_IN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Work_Center_ID,Product_ID,PRODUCED_IN_ID")] PRODUCED_IN pRODUCED_IN)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCED_IN.Add(pRODUCED_IN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", pRODUCED_IN.Product_ID);
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location", pRODUCED_IN.Work_Center_ID);
            return View(pRODUCED_IN);
        }

        // GET: PRODUCED_IN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCED_IN pRODUCED_IN = db.PRODUCED_IN.Find(id);
            if (pRODUCED_IN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", pRODUCED_IN.Product_ID);
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location", pRODUCED_IN.Work_Center_ID);
            return View(pRODUCED_IN);
        }

        // POST: PRODUCED_IN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Work_Center_ID,Product_ID,PRODUCED_IN_ID")] PRODUCED_IN pRODUCED_IN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCED_IN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", pRODUCED_IN.Product_ID);
            ViewBag.Work_Center_ID = new SelectList(db.WORK_CENTER, "Work_Center_ID", "Work_Center_Location", pRODUCED_IN.Work_Center_ID);
            return View(pRODUCED_IN);
        }

        // GET: PRODUCED_IN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCED_IN pRODUCED_IN = db.PRODUCED_IN.Find(id);
            if (pRODUCED_IN == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCED_IN);
        }

        // POST: PRODUCED_IN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCED_IN pRODUCED_IN = db.PRODUCED_IN.Find(id);
            db.PRODUCED_IN.Remove(pRODUCED_IN);
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
