using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week6b.Models;

namespace week6b.Controllers
{
    public class HomeController : Controller
    {
        ChirperContext db = new ChirperContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Chirps.ToList());
        }
    }
}