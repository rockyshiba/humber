using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week_6___Chirper.Models;

namespace Week_6___Chirper.Controllers
{
    public class HomeController : Controller
    {
        ChirperContext chirperContext = new ChirperContext();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            //Extract all chirps
            List<Chirp> chirps = chirperContext.Chirps.ToList();
            return View(chirps);
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return View(chirperContext.Chirps.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            return RedirectToAction("Index");
        }
    }
}