using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week6a.Models;

namespace week6a.Controllers
{
    public class ChirpController : Controller
    {
        ChirperContext chirperContext = new ChirperContext();
        // GET: Chirp
        public ActionResult Index()
        {
            return View(chirperContext.Chrips.ToList());
        }

        //Create a new chirp
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View(chirperContext.Chrips.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Chrip chirp)
        {
            chirperContext.Entry(chirp).State = System.Data.Entity.EntityState.Modified;
            chirperContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //Show a single instance of a chirp
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View(chirperContext.Chrips.Find(id));
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    //Form collection collects values from the form
        //    //Form associations are defined by the name attribute
        //    Chrip chirp = new Chrip();
        //    chirp.Title = formCollection["Title"];
        //    chirp.Username = formCollection["Username"];
        //    chirp.Email = formCollection["Email"];
        //    chirp.Comment = formCollection["Comment"];

        //    chirperContext.Chrips.Add(chirp);
        //    chirperContext.SaveChanges();

        //    return RedirectToAction("Index", "Home");
        //}

        [HttpPost]
        public ActionResult Create(Chrip chirp)
        {
            chirperContext.Chrips.Add(chirp);
            chirperContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                Chrip chirp = chirperContext.Chrips.Find(id);
                return View(chirp);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Chrip chirp)
        {
            chirperContext.Entry(chirp).State = System.Data.Entity.EntityState.Modified;
            chirperContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Chrip chirp = chirperContext.Chrips.Find(id);
            chirperContext.Chrips.Remove(chirp);
            chirperContext.SaveChanges();
            return RedirectToAction("Index", "Home");
            //if (id.HasValue)
            //{
            //    return View(chirperContext.Chrips.Find(id));
            //}
            //return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public ActionResult Delete(Chrip chirp)
        //{
        //    chirperContext.Chrips.Remove(chirp);
        //    chirperContext.SaveChanges();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}