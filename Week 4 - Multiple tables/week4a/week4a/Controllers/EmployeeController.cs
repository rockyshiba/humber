using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week4a.Models;

namespace week4a.Controllers
{
    public class EmployeeController : Controller
    {
        //context instance
        CompanyContext company = new CompanyContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: List of employees
        public ActionResult List()
        {
            //get all employees from the db
            List<Employee> employees = company.Employees.ToList();
            //pass employees into view
            return View(employees);
        }

        // GET: One employee
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                //Get one employee from the database by their id
                Employee employee = company.Employees.Single(emp => emp.Id == id);
                //pass this one employee into view
                return View(employee);
            }
            else
            {
                //if no id was provided in the url go to the index action
                return RedirectToAction("Index");
            }
        }
    }
}