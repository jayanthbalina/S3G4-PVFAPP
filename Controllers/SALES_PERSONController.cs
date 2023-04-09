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
    public class SALES_PERSONController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: SALES_PERSON
        public ActionResult Index()
        {
            var sALES_PERSON = db.SALES_PERSON.Include(s => s.SALES_TERRITORY);
            return View(sALES_PERSON.ToList());
        }

        // GET: SALES_PERSON/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES_PERSON sALES_PERSON = db.SALES_PERSON.Find(id);
            if (sALES_PERSON == null)
            {
                return HttpNotFound();
            }
            return View(sALES_PERSON);
        }

        // GET: SALES_PERSON/Create
        public ActionResult Create()
        {
            ViewBag.Territory_ID = new SelectList(db.SALES_TERRITORY, "Territory_ID", "Territory_Name");
            return View();
        }

        // POST: SALES_PERSON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Salesperson_ID,Salesperson_Name,Salesperson_Telephone,Salesperson_Fax,Territory_ID")] SALES_PERSON sALES_PERSON)
        {
            if (ModelState.IsValid)
            {
                db.SALES_PERSON.Add(sALES_PERSON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Territory_ID = new SelectList(db.SALES_TERRITORY, "Territory_ID", "Territory_Name", sALES_PERSON.Territory_ID);
            return View(sALES_PERSON);
        }

        // GET: SALES_PERSON/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES_PERSON sALES_PERSON = db.SALES_PERSON.Find(id);
            if (sALES_PERSON == null)
            {
                return HttpNotFound();
            }
            ViewBag.Territory_ID = new SelectList(db.SALES_TERRITORY, "Territory_ID", "Territory_Name", sALES_PERSON.Territory_ID);
            return View(sALES_PERSON);
        }

        // POST: SALES_PERSON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Salesperson_ID,Salesperson_Name,Salesperson_Telephone,Salesperson_Fax,Territory_ID")] SALES_PERSON sALES_PERSON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALES_PERSON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Territory_ID = new SelectList(db.SALES_TERRITORY, "Territory_ID", "Territory_Name", sALES_PERSON.Territory_ID);
            return View(sALES_PERSON);
        }

        // GET: SALES_PERSON/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALES_PERSON sALES_PERSON = db.SALES_PERSON.Find(id);
            if (sALES_PERSON == null)
            {
                return HttpNotFound();
            }
            return View(sALES_PERSON);
        }

        // POST: SALES_PERSON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALES_PERSON sALES_PERSON = db.SALES_PERSON.Find(id);
            db.SALES_PERSON.Remove(sALES_PERSON);
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
