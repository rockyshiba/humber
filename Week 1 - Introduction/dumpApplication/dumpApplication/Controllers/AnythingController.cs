using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dumpApplication.Controllers
{
    public class AnythingController : Controller
    {
        // GET: Anything
        public string Index()
        {
            return "This is the index of Anything Controller";
        }

        public string Something()
        {
            return "this is coming from the something method of the Anything controller";
        }
    }
}