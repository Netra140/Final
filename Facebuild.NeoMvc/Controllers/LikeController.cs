using Microsoft.AspNet.Identity;
using Facebuild.Models;
using Facebuild.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebuild.Models.Likes;

namespace Facebuild.NeoMvc.Controllers
{
    public class LikeController : Controller
    {
        public ActionResult List(int id)
        {//?sort=_created
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LikeService(userId, id);
            var model = service.GetLikes(id);
            /*switch (sort)
            {
                case "_created":
                    model = model.OrderBy(BuildListItem => BuildListItem.CreatedUtc);
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

            }*/

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LikeCreate model, int id)
        {
            int theirLikes = CreateLikeService(id).GetLikesByUser(id).Count();
            if (theirLikes >= 1)
            {
                return Redirect("../Delete/" + id);
            }

            //return RedirectToAction("" + id);
            model.BuildId = id;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new LikeService(userId, id);

            service.CreateLike(model, id);

            triggerCount(id);

            return RedirectToAction("../Build");
        }

        public void triggerCount(int buildId)
        {
            BuildService bServe = CreateBuildService();
            LikeService lServe = CreateLikeService(buildId);
            var likeList = lServe.GetLikes(buildId);
            int likes = likeList.Count();
            bServe.LikeCount(likes,buildId);
            
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLikeService(0);
            var model = svc.GetLikeByIdForDel(id);
            svc.DeleteLike(model.Id);
            TempData["SaveResult"] = "Your build was deleted";

            triggerCount(id);

            return RedirectToAction("../Build");

            return View(model);
        }
        private LikeService CreateLikeService(int buildId)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LikeService(userId, buildId);
            return service;
        }
        private BuildService CreateBuildService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BuildService(userId);
            return service;
        }
    }
}