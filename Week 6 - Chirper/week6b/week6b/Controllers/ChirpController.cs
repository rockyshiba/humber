using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week6b.Models;

namespace week6b.Controllers
{
    public class ChirpController : Controller
    {
        ChirperContext db = new ChirperContext();
        // GET: Chirp
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCreate(Chirp chirp)
        {
            db.Chirps.Add(chirp);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                return View(db.Chirps.Find(id));
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Edit(Chirp chirp)
        {
            db.Entry(chirp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //Create a new chirp
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    Chirp chirp = new Chirp();
        //    chirp.Title = formCollection["Title"];
        //    chirp.Username = formCollection["Username"];
        //    chirp.Email = formCollection["Email"];
        //    chirp.Comment = formCollection["Comment"];

        //    db.Chirps.Add(chirp);
        //    db.SaveChanges();

        //    return RedirectToAction("Index", "Home");
        //}

        [HttpPost]
        public ActionResult Create(Chirp chirp)
        {
            //chirp.Title = "Overridden title";'
            db.Chirps.Add(chirp);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            //return View(db.Chirps.Single(c => c.Id == id));
            return View(db.Chirps.Find(id));
        }

        [HttpPost]
        public ActionResult Update(Chirp chirp)
        {
            //Add in Id input through console and see if it alters Id in database

            db.Entry(chirp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                db.Chirps.Remove(db.Chirps.Find(id));
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult NewDelete(int? id)
        {
            return View(db.Chirps.Find(id));
        }
    }
}