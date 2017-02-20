using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using week6a.Models;

namespace week6a.Controllers
{
    public class AutomaticController : Controller
    {
        private ChirperContext db = new ChirperContext();

        // GET: Automatic
        public ActionResult Index()
        {
            return View(db.Chrips.ToList());
        }

        // GET: Automatic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chrip chrip = db.Chrips.Find(id);
            if (chrip == null)
            {
                return HttpNotFound();
            }
            return View(chrip);
        }

        // GET: Automatic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Automatic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Username,Email,Comment")] Chrip chrip)
        {
            if (ModelState.IsValid)
            {
                db.Chrips.Add(chrip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chrip);
        }

        // GET: Automatic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chrip chrip = db.Chrips.Find(id);
            if (chrip == null)
            {
                return HttpNotFound();
            }
            return View(chrip);
        }

        // POST: Automatic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Username,Email,Comment")] Chrip chrip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chrip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chrip);
        }

        // GET: Automatic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chrip chrip = db.Chrips.Find(id);
            if (chrip == null)
            {
                return HttpNotFound();
            }
            return View(chrip);
        }

        // POST: Automatic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chrip chrip = db.Chrips.Find(id);
            db.Chrips.Remove(chrip);
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
