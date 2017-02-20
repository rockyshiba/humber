using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week6a.Models;

namespace week6a.Controllers
{
    public class HomeController : Controller
    {
        ChirperContext chirperContext = new ChirperContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(chirperContext.Chrips.ToList());
        }
    }
}