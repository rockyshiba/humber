using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week2a.Models;

namespace week2a.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index(int id)
        {
            //return a single row from database
            PetContext petContext = new PetContext();
            //lambda expressions
            Pet pet = petContext.Pets.Single(itam => itam.Id == id);
            return View(pet);
        }

        public ActionResult Directory(int id) //actions can take in arguments
        {
            PetContext petContext = new PetContext();
            //match up an id with an id in the database
            Pet pet = petContext.Pets.Single(p => p.Id == id);
            return View(pet);
        }

        public ActionResult Find(string name)
        {
            //This will not work. Instead of single, use Find.
            PetContext petContext = new PetContext();
            Pet foundPet = petContext.Pets.Single(p => p.Name == name);
            return View(foundPet);
        }
    }
}