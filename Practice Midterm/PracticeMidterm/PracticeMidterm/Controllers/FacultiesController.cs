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
            //the faculty to delete found by its id
            Faculty faculty = db.Faculties.Find(id);

            //We are also adding an entry to Retired_faculty table so we need a new instance of the Retired_faculty class
            Retired_faculty retired = new Retired_faculty();
            //each property of this retired object will match the faculty member about to be deleted so we can simply assign the properties of the retired object with the properties of the faculty object
            retired.Id = faculty.Id;
            retired.First_name = faculty.First_name;
            retired.Last_name = faculty.Last_name;

            //We need to assign a program name. There are two methods here. 
            //First, you can grab a program from the database from the program_id of the faculty member to be deleted, then assign the program_name property of the retired object with the Name of the program object we just grabbed. 

            //Program program = db.Programs.Find(faculty.Program_id);
            //retired.Program_name = program.Name;

            //Second, because faculty and programs are related in the database, you can access the program object related with the faculty object. You can then access the Name property of the program related to the faculty object. 
            retired.Program_name = faculty.Program.Name;

            //Remove the faculty object from the Faculty table
            db.Faculties.Remove(faculty);
            //Add the retired object we made using the faculty object from the code above
            db.Retired_faculty.Add(retired);
            //Save the Remove and Add actions with the SaveChanges() method
            db.SaveChanges();
            //Go to the Retired page
            return RedirectToAction("Index", "Retired");
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
