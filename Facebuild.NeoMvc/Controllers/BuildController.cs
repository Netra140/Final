using Facebuild.Data.Pallets;
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
        public ActionResult Index(string sort, string filter)
        {//?sort=_created
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BuildService(userId);
            var model = service.GetBuilds();
            switch (sort)
            {
                case "_created":
                        model = model.OrderByDescending(BuildListItem => BuildListItem.CreatedUtc);
                    break;
                case "_alphabet":
                    model = model.OrderBy(BuildListItem => BuildListItem.Name);
                    break;
                case "_likes":
                    model = model.OrderByDescending(BuildListItem => BuildListItem.Likes);
                    break;
                default:
                    model = model.OrderByDescending(BuildListItem => BuildListItem.CreatedUtc);
                    break;

            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuildCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            
            var service = new BuildService(userId);

            service.CreateBuild(model);

            IEnumerable<BuildListItem> buildings = service.GetBuilds();
            buildings = buildings.OrderByDescending(BuildListItem => BuildListItem.CreatedUtc);
            int link = buildings.First().BuildId;

            return Redirect("../Pallet/Create/" + link);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBuildService();
            var model = svc.GetBuildById(id);

            return View(model);
        }
        [HttpGet]
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

        public ActionResult AddPallet(int id, Pallet pal)
        {
            var service = CreateBuildService();
            var detail = service.GetBuildById(id);
            var model =
                new BuildEdit
                {
                    BuildId = detail.BuildId,
                    Name = detail.Name,
                    Description = detail.Description,
                    pallet = pal
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
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost (int id)
        {
            var service = CreateBuildService();
            string iFrame = service.GetBuildById(id).iframeSrc;
            iFrame = iFrame.TrimStart(new char[] { '.','.','/','.','.','/','P','a','l','l','e','t','/','D','e','t','a','i','l','s','/'});
            int palletId = int.Parse(iFrame);
            service.DeleteBuild(id);
            TempData["SaveResult"] = "Your build was deleted";
            return RedirectToAction ("../Pallet/Delete/" + palletId);
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