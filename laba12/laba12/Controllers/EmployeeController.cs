using laba12.Models;
using laba12.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba12.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService = new EmployeeService();

        public ActionResult List()
        {
            var model = employeeService.GetEmployeesList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            employeeService.InsertEmployee(model);

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var model = employeeService.GetEmployeeById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            employeeService.UpdateEmployee(model);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            employeeService.DeleteEmployee(id);

            return RedirectToAction("List");
        }
    }
}
