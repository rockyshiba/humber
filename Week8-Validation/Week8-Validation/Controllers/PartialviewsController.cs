using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week8_Validation.Models;

namespace Week8_Validation.Controllers
{
    public class PartialviewsController : Controller
    {
        SchoolContext db = new SchoolContext();
        // GET: Partialviews
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Students()
        {
            //grab all students from database
            List<Student> students = db.Students.ToList();
            return PartialView("_ExamplePartialData", students);
        }

        public PartialViewResult StudentsByName()
        {
            //get all students ordered by last name
            List<Student> students = db.Students.OrderBy(stus => stus.Last_name).ToList();
            return PartialView("_ExamplePartialData", students);
        }
    }
}