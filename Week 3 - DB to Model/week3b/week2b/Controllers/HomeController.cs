using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week2b.Models;

namespace week2b.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Car car = new Car();
            car.Name = "My car";
            car.Manufacturer = "Toyota";
            car.Price = 10000;

            Car car2 = new Car();
            car2.Name = "Your car";
            car2.Manufacturer = "Honda";
            car2.Price = 20000;

            //array holding cars
            Car[] cars = new Car[] { car, car2 }; 
            ViewData["cars"] = cars;
            
            return View();
        }

        public ActionResult Pets()
        {
            PetContext petContext = new PetContext(); //petContext class
            List<Pet> pet = petContext.Pets.ToList(); //store db contents into Pet object
            return View(pet);
        }
    }
}