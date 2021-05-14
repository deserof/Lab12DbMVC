using laba12.Models;
using laba12.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba12.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentService departmentService = new DepartmentService();

        public ActionResult List()
        {
            var model = departmentService.GetDepartmentsList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department model)
        {
            departmentService.InsertDepartment(model);

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var model = departmentService.GetDepartmentById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Department model)
        {
            departmentService.UpdateDepartment(model);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            departmentService.DeleteDepartment(id);

            return RedirectToAction("List");
        }
    }
}
