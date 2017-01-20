using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week2b.Models;

namespace week2b.Controllers
{
    public class DayController : Controller
    {
        // GET: Day
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Morning()
        {
            Machine orange = new Machine();
            orange.Name = "My machine";
            orange.Price = 99.99;
            orange.Inventory = 4;

            Machine orange1 = new Machine();
            orange1.Name = "Your machine";
            orange1.Price = 89.99;
            orange1.Inventory = 8;
            return View(orange);
        }
    }
}