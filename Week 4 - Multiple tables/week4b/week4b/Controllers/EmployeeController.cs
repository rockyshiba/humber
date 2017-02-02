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

        //GET: list of deparments employee/departments
        public ActionResult Departments()
        {
            List<Department> departments = companyContext.Departments.ToList();
            return View(departments);
        }

        //GET: Employees related to department
        public ActionResult Directory(int? id)
        {
            //Return a list of employees based on their department id
            List<Employee> employees = companyContext.Employees.Where(emp => emp.Department_id == id).ToList();
            return View(employees);
        }
    }
}