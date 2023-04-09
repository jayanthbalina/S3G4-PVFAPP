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
    public class VENDORsController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: VENDORs
        public ActionResult Index()
        {
            return View(db.VENDOR.ToList());
        }

        // GET: VENDORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR vENDOR = db.VENDOR.Find(id);
            if (vENDOR == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR);
        }

        // GET: VENDORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VENDORs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vendor_ID,Vendor_Name,Vendor_Address")] VENDOR vENDOR)
        {
            if (ModelState.IsValid)
            {
                db.VENDOR.Add(vENDOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vENDOR);
        }

        // GET: VENDORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR vENDOR = db.VENDOR.Find(id);
            if (vENDOR == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR);
        }

        // POST: VENDORs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vendor_ID,Vendor_Name,Vendor_Address")] VENDOR vENDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vENDOR);
        }

        // GET: VENDORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR vENDOR = db.VENDOR.Find(id);
            if (vENDOR == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR);
        }

        // POST: VENDORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENDOR vENDOR = db.VENDOR.Find(id);
            db.VENDOR.Remove(vENDOR);
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
