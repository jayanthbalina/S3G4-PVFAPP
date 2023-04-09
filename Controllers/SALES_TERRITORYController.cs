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
    public class SALES_TERRITORYController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: SALES_TERRITORY
        public ActionResult Index()
        {
            return View(db.SALES_TERRITORY.ToList());
        }

        // GET: SALES_TERRITORY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES_TERRITORY sALES_TERRITORY = db.SALES_TERRITORY.Find(id);
            if (sALES_TERRITORY == null)
            {
                return HttpNotFound();
            }
            return View(sALES_TERRITORY);
        }

        // GET: SALES_TERRITORY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SALES_TERRITORY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Territory_ID,Territory_Name")] SALES_TERRITORY sALES_TERRITORY)
        {
            if (ModelState.IsValid)
            {
                db.SALES_TERRITORY.Add(sALES_TERRITORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALES_TERRITORY);
        }

        // GET: SALES_TERRITORY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES_TERRITORY sALES_TERRITORY = db.SALES_TERRITORY.Find(id);
            if (sALES_TERRITORY == null)
            {
                return HttpNotFound();
            }
            return View(sALES_TERRITORY);
        }

        // POST: SALES_TERRITORY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Territory_ID,Territory_Name")] SALES_TERRITORY sALES_TERRITORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALES_TERRITORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALES_TERRITORY);
        }

        // GET: SALES_TERRITORY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES_TERRITORY sALES_TERRITORY = db.SALES_TERRITORY.Find(id);
            if (sALES_TERRITORY == null)
            {
                return HttpNotFound();
            }
            return View(sALES_TERRITORY);
        }

        // POST: SALES_TERRITORY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALES_TERRITORY sALES_TERRITORY = db.SALES_TERRITORY.Find(id);
            db.SALES_TERRITORY.Remove(sALES_TERRITORY);
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
