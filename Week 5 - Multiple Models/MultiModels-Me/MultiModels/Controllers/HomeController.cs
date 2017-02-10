using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiModels.Models;

namespace MultiModels.Controllers
{
    public class HomeController : Controller
    {
        HumberContext humberContext = new HumberContext();
        // GET: Home
        public ActionResult Index()
        {
            //Views are strongly typed to a model
            //To utilize multiple models on a view, make a view model with properties of other models
            ProgramsFacultyStudents fpc = new ProgramsFacultyStudents();

            //The object fpc has three properties: faculty, programs, students
            //Each of these properties is of type List of a model

            fpc.faculty = humberContext.Faculties.ToList();
            fpc.programs = humberContext.Programs.ToList();
            fpc.students = humberContext.Students.ToList();

            //In this case, we are assigning a list of database rows to each property of the fpc object
            //We can then pass this object to the view
            return View(fpc);
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            //Return the view on page load (right click Go To View)
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(FormCollection formCollection)
        {
            //FormCollection allows the collection of input from HTML tags using the name attribute
            Student student = new Student();
            student.f_name = formCollection["f_name"];
            student.l_name = formCollection["l_name"];
            student.Student_num = formCollection["Student_num"];
            student.Program_Id = Convert.ToInt32(formCollection["Program_Id"]);

            //Adding to the students table in the database a new student object with its properties defined in the lines above
            humberContext.Students.Add(student);
            //You must commit changes to the database using the SaveChanges() method
            humberContext.SaveChanges();

            //Returning to the same view with the newly made student object
            return View(student);
        }
    }
}