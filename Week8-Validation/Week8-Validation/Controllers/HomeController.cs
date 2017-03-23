using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Week8_Validation.Models;

namespace Week8_Validation.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();
        // GET: Home
        [HttpGet]
        public ActionResult Index(string lang = "eng")
        {
            //(root)/home/index?lang={value}
            //This is a get request
            //Like HttpPost, we can provide arguments for our get request
            //Get request variables are declared in query strings, the statements after the ? in a url string
            //We can assign default values in our arugments by assigning them here 
            //Default values will be overwritten by the url string
            //That means if (root)/home/index?lang=fr, then the database will bring forth the row where Lang = fr
            Homepage homepage = db.Homepages.Single(hom => hom.Lang == lang);
            if(homepage == null)
            {
                return View(db.Homepages.Single(hom => hom.Lang == "eng"));
            }
            return View(homepage);
        }

        public PartialViewResult Students()
        {
            List<Student> stus = db.Students.ToList();
            return PartialView("_StudentsData", stus);
        }

        public PartialViewResult StudentsByName()
        {
            List<Student> stus = db.Students.OrderBy(stu => stu.Last_name).ToList();
            return PartialView("_StudentsData", stus);
        }
    }
}