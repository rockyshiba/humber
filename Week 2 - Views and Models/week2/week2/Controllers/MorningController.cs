using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace week2.Controllers
{
    public class MorningController : Controller
    {
        // GET: Morning
        public ActionResult Index()
        {
            return View();
        }

        public string Greeting()
        {
            return "Good morning";
        }
    }
}