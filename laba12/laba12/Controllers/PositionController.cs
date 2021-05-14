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
    public class PositionController : Controller
    {
        private PositionService positionService = new PositionService();

        public ActionResult List()
        {
            var model = positionService.GetPositionsList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Position model)
        {
            positionService.InsertPosition(model);

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var model = positionService.GetPositionById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Position model)
        {
            positionService.UpdatePosition(model);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            positionService.DeletePosition(id);

            return RedirectToAction("List");
        }
    }
}
