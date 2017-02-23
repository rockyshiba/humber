using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeMidterm.Models;

namespace PracticeMidterm.Controllers
{
    public class RetiredController : Controller
    {
        HumberContext db = new HumberContext();
        // GET: Retired
        public ActionResult Index()
        {
            return View(db.Retired_faculty.ToList());
        }
    }
}