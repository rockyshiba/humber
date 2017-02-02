using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week4b.Models;

namespace week4b.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext companyContext = new CompanyContext();
        // GET: Employee
        public ActionResult Index()
        {
            //List of all employees in db
            List<Employee> employees = companyContext.Employees.ToList();
            return View(employees);
        }

        //GET: one Employee
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Employee employee = companyContext.Employees.Single(emp => emp.Id == id);
                return View(employee);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}