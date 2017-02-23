using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracticeMidterm.Models;

namespace PracticeMidterm.Controllers
{
    public class FacultiesController : Controller
    {
        private HumberContext db = new HumberContext();

        // GET: Faculties
        public ActionResult Index()
        {
            var faculties = db.Faculties.Include(f => f.Program);
            return View(faculties.ToList());
        }

        // GET: Faculties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // GET: Faculties/Create
        public ActionResult Create()
        {
            ViewBag.Program_id = new SelectList(db.Programs, "Id", "Name");
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_name,Last_name,Program_id")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Faculties.Add(faculty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Program_id = new SelectList(db.Programs, "Id", "Name", faculty.Program_id);
            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            ViewBag.Program_id = new SelectList(db.Programs, "Id", "Name", faculty.Program_id);
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_name,Last_name,Program_id")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Program_id = new SelectList(db.Programs, "Id", "Name", faculty.Program_id);
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty faculty = db.Faculties.Find(id);

            Retired_faculty retired = new Retired_faculty();
            retired.Id = faculty.Id;
            retired.First_name = faculty.First_name;
            retired.Last_name = faculty.Last_name;

            Program program = db.Programs.Find(faculty.Program_id);
            retired.Program_name = program.Name;
            //retired.Program_name = faculty.Program.Name;

            db.Faculties.Remove(faculty);
            db.Retired_faculty.Add(retired);
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
