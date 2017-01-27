using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week2a.Models;

namespace week2a.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            PetContext petContext = new PetContext();
            List<Pet> pets = petContext.Pets.ToList();
            return View(pets);
        }
    }
}