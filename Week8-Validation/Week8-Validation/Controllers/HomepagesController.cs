using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week8_Validation.Models;

namespace Week8_Validation.Controllers
{
    public class HomepagesController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Homepages
        public ActionResult Index()
        {
            return View(db.Homepages.ToList());
        }

        // GET: Homepages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homepage homepage = db.Homepages.Find(id);
            if (homepage == null)
            {
                return HttpNotFound();
            }
            return View(homepage);
        }

        // GET: Homepages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Homepages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Subtitle,Body,Lang")] Homepage homepage)
        {
            if (ModelState.IsValid)
            {
                db.Homepages.Add(homepage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homepage);
        }

        // GET: Homepages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homepage homepage = db.Homepages.Find(id);
            if (homepage == null)
            {
                return HttpNotFound();
            }
            return View(homepage);
        }

        // POST: Homepages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Subtitle,Body,Lang")] Homepage homepage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homepage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homepage);
        }

        // GET: Homepages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homepage homepage = db.Homepages.Find(id);
            if (homepage == null)
            {
                return HttpNotFound();
            }
            return View(homepage);
        }

        // POST: Homepages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Homepage homepage = db.Homepages.Find(id);
            db.Homepages.Remove(homepage);
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
