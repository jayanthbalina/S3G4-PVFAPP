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
    public class SUPPLIESController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: SUPPLIES
        public ActionResult Index()
        {
            var sUPPLIES = db.SUPPLIES.Include(s => s.RAW_MATERIAL).Include(s => s.VENDOR);
            return View(sUPPLIES.ToList());
        }

        // GET: SUPPLIES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIES sUPPLIES = db.SUPPLIES.Find(id);
            if (sUPPLIES == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIES);
        }

        // GET: SUPPLIES/Create
        public ActionResult Create()
        {
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name");
            ViewBag.Vendor_ID = new SelectList(db.VENDOR, "Vendor_ID", "Vendor_Name");
            return View();
        }

        // POST: SUPPLIES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vendor_ID,Material_ID,Supply_Unit_Price,SUPPLIES_ID")] SUPPLIES sUPPLIES)
        {
            if (ModelState.IsValid)
            {
                db.SUPPLIES.Add(sUPPLIES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", sUPPLIES.Material_ID);
            ViewBag.Vendor_ID = new SelectList(db.VENDOR, "Vendor_ID", "Vendor_Name", sUPPLIES.Vendor_ID);
            return View(sUPPLIES);
        }

        // GET: SUPPLIES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIES sUPPLIES = db.SUPPLIES.Find(id);
            if (sUPPLIES == null)
            {
                return HttpNotFound();
            }
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", sUPPLIES.Material_ID);
            ViewBag.Vendor_ID = new SelectList(db.VENDOR, "Vendor_ID", "Vendor_Name", sUPPLIES.Vendor_ID);
            return View(sUPPLIES);
        }

        // POST: SUPPLIES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vendor_ID,Material_ID,Supply_Unit_Price,SUPPLIES_ID")] SUPPLIES sUPPLIES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUPPLIES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", sUPPLIES.Material_ID);
            ViewBag.Vendor_ID = new SelectList(db.VENDOR, "Vendor_ID", "Vendor_Name", sUPPLIES.Vendor_ID);
            return View(sUPPLIES);
        }

        // GET: SUPPLIES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPPLIES sUPPLIES = db.SUPPLIES.Find(id);
            if (sUPPLIES == null)
            {
                return HttpNotFound();
            }
            return View(sUPPLIES);
        }

        // POST: SUPPLIES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUPPLIES sUPPLIES = db.SUPPLIES.Find(id);
            db.SUPPLIES.Remove(sUPPLIES);
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
