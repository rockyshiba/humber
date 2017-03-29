using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week9_Authorization.Models;

namespace Week9_Authorization.Controllers
{
    [Authorize(Roles = "user, admin")] //authorization is now on all actions in this controller when declared above the controller definition
    public class ProgramsController : Controller
    {
        private SecretHQContext db = new SecretHQContext();

        // GET: Programs
        public ActionResult Index()
        {
            var programs = db.Programs.Include(p => p.Instructors1);
            return View(programs.ToList());
        }

        [AllowAnonymous] //This allows unauthorized users
        // GET: Programs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programs programs = db.Programs.Find(id);
            if (programs == null)
            {
                return HttpNotFound();
            }
            return View(programs);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            ViewBag.Program_head = new SelectList(db.Instructors, "Id", "F_name");
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Program_name,Program_head")] Programs programs)
        {
            if (ModelState.IsValid)
            {
                db.Programs.Add(programs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Program_head = new SelectList(db.Instructors, "Id", "F_name", programs.Program_head);
            return View(programs);
        }

        // GET: Programs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programs programs = db.Programs.Find(id);
            if (programs == null)
            {
                return HttpNotFound();
            }
            ViewBag.Program_head = new SelectList(db.Instructors, "Id", "F_name", programs.Program_head);
            return View(programs);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Program_name,Program_head")] Programs programs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Program_head = new SelectList(db.Instructors, "Id", "F_name", programs.Program_head);
            return View(programs);
        }

        // GET: Programs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programs programs = db.Programs.Find(id);
            if (programs == null)
            {
                return HttpNotFound();
            }
            return View(programs);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programs programs = db.Programs.Find(id);
            db.Programs.Remove(programs);
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
