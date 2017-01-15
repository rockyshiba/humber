using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dumpApplication.Controllers
{
    //The Home controller points to the root of .NET MVC solutions
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "This is the home controller. It can be accessed without declaring the name of the controller";
        }

        public string About()
        {
            return "This is the about page";
        }
    }
}