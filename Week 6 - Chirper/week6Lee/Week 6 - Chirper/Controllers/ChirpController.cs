using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week_6___Chirper.Models;

namespace Week_6___Chirper.Controllers
{
    public class ChirpController : Controller
    {
        ChirperContext chirperContext = new ChirperContext();

        // GET: Chirp
        public ActionResult Index()
        {
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return View(chirperContext.Chirps.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            //no model be will returned. We are creating a new model in this instance.
            return View();
        }

        [HttpPost]
        public ActionResult Create(Chirp chirp)
        {
            chirperContext.Chirps.Add(chirp);
            chirperContext.SaveChanges();
            return RedirectToAction("Admin");
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{

        //    return RedirectToAction("Admin");
        //}

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Chirp chirp = chirperContext.Chirps.Single(c => c.Id == id);
            return View(chirp);
        }

        [HttpPost]
        public ActionResult Edit(Chirp chirp)
        {
            chirperContext.Entry(chirp).State = System.Data.Entity.EntityState.Modified;
            chirperContext.SaveChanges();
            return RedirectToAction("Admin");   
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Chirp chirp = chirperContext.Chirps.Find(id);
            return View(chirp);
        }

        [HttpPost]
        public ActionResult Delete(Chirp chirp)
        {
            chirperContext.Chirps.Remove(chirp);
            chirperContext.SaveChanges();
            return RedirectToAction("Admin");
        }
    }
}