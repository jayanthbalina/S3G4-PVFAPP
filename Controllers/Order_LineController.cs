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
    public class Order_LineController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: Order_Line
        public ActionResult Index()
        {
            var order_Line = db.Order_Line.Include(o => o.ORDER).Include(o => o.PRODUCT);
            return View(order_Line.ToList());
        }

        // GET: Order_Line/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            return View(order_Line);
        }

        // GET: Order_Line/Create
        public ActionResult Create()
        {
            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Order_ID");
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description");
            return View();
        }

        // POST: Order_Line/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_ID,Product_ID,Order_Quantity,Order_Line_ID")] Order_Line order_Line)
        {
            if (ModelState.IsValid)
            {
                db.Order_Line.Add(order_Line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Order_ID", order_Line.Order_ID);
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", order_Line.Product_ID);
            return View(order_Line);
        }

        // GET: Order_Line/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Order_ID", order_Line.Order_ID);
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", order_Line.Product_ID);
            return View(order_Line);
        }

        // POST: Order_Line/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_ID,Product_ID,Order_Quantity,Order_Line_ID")] Order_Line order_Line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_ID = new SelectList(db.ORDER, "Order_ID", "Order_ID", order_Line.Order_ID);
            ViewBag.Product_ID = new SelectList(db.PRODUCT, "Product_ID", "Product_Description", order_Line.Product_ID);
            return View(order_Line);
        }

        // GET: Order_Line/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            return View(order_Line);
        }

        // POST: Order_Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Line order_Line = db.Order_Line.Find(id);
            db.Order_Line.Remove(order_Line);
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
