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
    public class HAS_SKILLController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: HAS_SKILL
        public ActionResult Index()
        {
            var hAS_SKILL = db.HAS_SKILL.Include(h => h.EMPLOYEE).Include(h => h.SKILL);
            return View(hAS_SKILL.ToList());
        }

        // GET: HAS_SKILL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAS_SKILL hAS_SKILL = db.HAS_SKILL.Find(id);
            if (hAS_SKILL == null)
            {
                return HttpNotFound();
            }
            return View(hAS_SKILL);
        }

        // GET: HAS_SKILL/Create
        public ActionResult Create()
        {
            ViewBag.EMPLOYEE_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name");
            ViewBag.SKILL_CODE = new SelectList(db.SKILL, "SKILL_CODE", "SKILL_DESCRIPTION");
            return View();
        }

        // POST: HAS_SKILL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SKILL_CODE,EMPLOYEE_ID,SKILL_ID")] HAS_SKILL hAS_SKILL)
        {
            if (ModelState.IsValid)
            {
                db.HAS_SKILL.Add(hAS_SKILL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMPLOYEE_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", hAS_SKILL.EMPLOYEE_ID);
            ViewBag.SKILL_CODE = new SelectList(db.SKILL, "SKILL_CODE", "SKILL_DESCRIPTION", hAS_SKILL.SKILL_CODE);
            return View(hAS_SKILL);
        }

        // GET: HAS_SKILL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAS_SKILL hAS_SKILL = db.HAS_SKILL.Find(id);
            if (hAS_SKILL == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPLOYEE_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", hAS_SKILL.EMPLOYEE_ID);
            ViewBag.SKILL_CODE = new SelectList(db.SKILL, "SKILL_CODE", "SKILL_DESCRIPTION", hAS_SKILL.SKILL_CODE);
            return View(hAS_SKILL);
        }

        // POST: HAS_SKILL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SKILL_CODE,EMPLOYEE_ID,SKILL_ID")] HAS_SKILL hAS_SKILL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hAS_SKILL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMPLOYEE_ID = new SelectList(db.EMPLOYEE, "Employee_ID", "Employee_Name", hAS_SKILL.EMPLOYEE_ID);
            ViewBag.SKILL_CODE = new SelectList(db.SKILL, "SKILL_CODE", "SKILL_DESCRIPTION", hAS_SKILL.SKILL_CODE);
            return View(hAS_SKILL);
        }

        // GET: HAS_SKILL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HAS_SKILL hAS_SKILL = db.HAS_SKILL.Find(id);
            if (hAS_SKILL == null)
            {
                return HttpNotFound();
            }
            return View(hAS_SKILL);
        }

        // POST: HAS_SKILL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HAS_SKILL hAS_SKILL = db.HAS_SKILL.Find(id);
            db.HAS_SKILL.Remove(hAS_SKILL);
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
