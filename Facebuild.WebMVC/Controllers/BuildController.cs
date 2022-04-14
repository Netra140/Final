using Facebuild.Models;
using Facebuild.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facebuild.WebMVC.Controllers
{
    [Authorize]
    public class BuildController : Controller
    {
        // GET: Build
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BuildService(userId);
            var model = service.GetBuilds();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuildCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBuildService();

            if (service.CreateBuild(model))
            {
                TempData["SaveResult"] = "Your build was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBuildService();
            var model = svc.GetBuildById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBuildService();
            var detail = service.GetBuildById(id);
            var model =
                new BuildEdit
                {
                    BuildId = detail.BuildId,
                    Name = detail.Name,
                    Description = detail.Description
                };
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBuildService();
            var model = svc.GetBuildById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BuildEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.BuildId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBuildService();

            if (service.UpdateBuild(model))
            {
                TempData["SaveResult"] = "Your Build was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your build could not be updated.");
            return View();
        }

        private BuildService CreateBuildService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BuildService(userId);
            return service;
        }
    }
}