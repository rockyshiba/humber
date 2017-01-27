using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week2b.Models;

namespace week2b.Controllers
{
    public class PetController : Controller
    {
        PetContext petContext = new PetContext();
        // GET: Pet
        public ActionResult Index(int apple)
        {
            //Lambda expressions
            Pet pet = petContext.Pets.Single(p => p.Id == apple);
            return View(pet);
        }

        public ActionResult Notindex()
        {
            List<Pet> pets = petContext.Pets.ToList();
            return View(pets);
        }

        public ActionResult Notindex(int id)
        {
            Pet pet = petContext.Pets.Single(p => p.Id == 1);
            Pet pet = petContext.Pets.Find
            return View(pet);
        }
    }
}