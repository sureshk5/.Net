using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ViewResult All()
        {
            var com = new SampleMvcApp.Models.EmpDataRepository();
            var table = com.GetAllEmployees();
            return View(table);//Model is DataTable...
        }

        public ViewResult Find(string id)
        {
            var empId = int.Parse(id);
            var com = new EmpDataRepository();
            var emp = com.Find(empId);
            return View(emp);
        }

        [HttpPost]
        public RedirectToRouteResult Find(Employee employee)
        {
            var com = new EmpDataRepository();
            com.Update(employee);
            return RedirectToAction("All");
        }

        public ActionResult Insert()
        {
            var emp = new Employee();
            return View(emp);//Blank Employee object....

        }
        [HttpPost]
        public ActionResult Insert(Employee emp)
        {
            var com = new EmpDataRepository();
            com.InsertEmployee(emp);
            return RedirectToAction("All");
        }

        
    }
}