using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using week6b.Models;

namespace week6b.Controllers
{
    public class NewChirpController : Controller
    {
        private ChirperContext db = new ChirperContext();

        // GET: NewChirp
        public ActionResult Index()
        {
            return View(db.Chirps.ToList());
        }

        // GET: NewChirp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chirp chirp = db.Chirps.Find(id);
            if (chirp == null)
            {
                return HttpNotFound();
            }
            return View(chirp);
        }

        // GET: NewChirp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewChirp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Username,Email,Comment")] Chirp chirp)
        {
            if (ModelState.IsValid)
            {
                db.Chirps.Add(chirp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chirp);
        }

        // GET: NewChirp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chirp chirp = db.Chirps.Find(id);
            if (chirp == null)
            {
                return HttpNotFound();
            }
            return View(chirp);
        }

        // POST: NewChirp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Username,Email,Comment")] Chirp chirp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chirp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chirp);
        }

        // GET: NewChirp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chirp chirp = db.Chirps.Find(id);
            if (chirp == null)
            {
                return HttpNotFound();
            }
            return View(chirp);
        }

        // POST: NewChirp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chirp chirp = db.Chirps.Find(id);
            db.Chirps.Remove(chirp);
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
