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
    public class USESController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: USES
        public ActionResult Index()
        {
            var uSES = db.USES.Include(u => u.PRODUCT).Include(u => u.RAW_MATERIAL);
            return View(uSES.ToList());
        }

        // GET: USES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USES uSES = db.USES.Find(id);
            if (uSES == null)
            {
                return HttpNotFound();
            }
            return View(uSES);
        }

        // GET: USES/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description");
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name");
            return View();
        }

        // POST: USES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Material_ID,Product_ID,USES_ID")] USES uSES)
        {
            if (ModelState.IsValid)
            {
                db.USES.Add(uSES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", uSES.Product_ID);
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", uSES.Material_ID);
            return View(uSES);
        }

        // GET: USES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USES uSES = db.USES.Find(id);
            if (uSES == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", uSES.Product_ID);
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", uSES.Material_ID);
            return View(uSES);
        }

        // POST: USES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Material_ID,Product_ID,USES_ID")] USES uSES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", uSES.Product_ID);
            ViewBag.Material_ID = new SelectList(db.RAW_MATERIAL, "Material_ID", "Material_Name", uSES.Material_ID);
            return View(uSES);
        }

        // GET: USES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USES uSES = db.USES.Find(id);
            if (uSES == null)
            {
                return HttpNotFound();
            }
            return View(uSES);
        }

        // POST: USES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USES uSES = db.USES.Find(id);
            db.USES.Remove(uSES);
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
