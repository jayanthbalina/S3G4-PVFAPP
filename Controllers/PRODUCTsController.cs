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
    public class PRODUCTsController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: PRODUCTs
        public ActionResult Index()
        {
            var pRODUCT = db.PRODUCT.Include(p => p.PRODUCT_LINE);
            return View(pRODUCT.ToList());
        }

        // GET: PRODUCTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Create
        public ActionResult Create()
        {
            ViewBag.Product_Line_ID = new SelectList(db.PRODUCT_LINE, "Product_Line_ID", "Product_Line_Name");
            return View();
        }

        // POST: PRODUCTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_ID,Product_Description,Product_Finish,Product_Standard_Price,Product_Line_ID")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCT.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_Line_ID = new SelectList(db.PRODUCT_LINE, "Product_Line_ID", "Product_Line_Name", pRODUCT.Product_Line_ID);
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_Line_ID = new SelectList(db.PRODUCT_LINE, "Product_Line_ID", "Product_Line_Name", pRODUCT.Product_Line_ID);
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_ID,Product_Description,Product_Finish,Product_Standard_Price,Product_Line_ID")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_Line_ID = new SelectList(db.PRODUCT_LINE, "Product_Line_ID", "Product_Line_Name", pRODUCT.Product_Line_ID);
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            db.PRODUCT.Remove(pRODUCT);
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
