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
    public class DOES_BUSINESS_INController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: DOES_BUSINESS_IN
        public ActionResult Index()
        {
            var dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Include(d => d.Customer).Include(d => d.SALES_TERRITORY);
            return View(dOES_BUSINESS_IN.ToList());
        }

        // GET: DOES_BUSINESS_IN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOES_BUSINESS_IN dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Find(id);
            if (dOES_BUSINESS_IN == null)
            {
                return HttpNotFound();
            }
            return View(dOES_BUSINESS_IN);
        }

        // GET: DOES_BUSINESS_IN/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name");
            ViewBag.Territory_ID = new SelectList(db.SALES_TERRITORY, "Territory_ID", "Territory_Name");
            return View();
        }

        // POST: DOES_BUSINESS_IN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Territory_ID,Customer_ID,DOES_BUSINESS_ID")] DOES_BUSINESS_IN dOES_BUSINESS_IN)
        {
            if (ModelState.IsValid)
            {
                db.DOES_BUSINESS_IN.Add(dOES_BUSINESS_IN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", dOES_BUSINESS_IN.Customer_ID);
            ViewBag.Territory_ID = new SelectList(db.SALES_TERRITORY, "Territory_ID", "Territory_Name", dOES_BUSINESS_IN.Territory_ID);
            return View(dOES_BUSINESS_IN);
        }

        // GET: DOES_BUSINESS_IN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOES_BUSINESS_IN dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Find(id);
            if (dOES_BUSINESS_IN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", dOES_BUSINESS_IN.Customer_ID);
            ViewBag.Territory_ID = new SelectList(db.SALES_TERRITORY, "Territory_ID", "Territory_Name", dOES_BUSINESS_IN.Territory_ID);
            return View(dOES_BUSINESS_IN);
        }

        // POST: DOES_BUSINESS_IN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Territory_ID,Customer_ID,DOES_BUSINESS_ID")] DOES_BUSINESS_IN dOES_BUSINESS_IN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOES_BUSINESS_IN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", dOES_BUSINESS_IN.Customer_ID);
            ViewBag.Territory_ID = new SelectList(db.SALES_TERRITORY, "Territory_ID", "Territory_Name", dOES_BUSINESS_IN.Territory_ID);
            return View(dOES_BUSINESS_IN);
        }

        // GET: DOES_BUSINESS_IN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOES_BUSINESS_IN dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Find(id);
            if (dOES_BUSINESS_IN == null)
            {
                return HttpNotFound();
            }
            return View(dOES_BUSINESS_IN);
        }

        // POST: DOES_BUSINESS_IN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOES_BUSINESS_IN dOES_BUSINESS_IN = db.DOES_BUSINESS_IN.Find(id);
            db.DOES_BUSINESS_IN.Remove(dOES_BUSINESS_IN);
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
