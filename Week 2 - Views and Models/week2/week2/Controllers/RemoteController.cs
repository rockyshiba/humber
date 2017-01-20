using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week2.Models;

namespace week2.Controllers
{
    public class RemoteController : Controller
    {
        // GET: Remote
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TV()
        {
            Machine orange = new Machine();
            orange.Name = "Lee's computer";
            orange.Price = 100.00;
            orange.Model = "1a";
            return View(orange);
        }
    }
}