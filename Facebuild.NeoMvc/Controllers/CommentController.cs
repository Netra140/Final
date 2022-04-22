using Facebuild.Models.Comments;
using Facebuild.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facebuild.NeoMvc.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
            public ActionResult List(int id)
            {//?sort=_created
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new CommentService(userId, id);
                var model = service.GetComments(id);
                return View(model);
            }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate model, int id)
        {

            //return RedirectToAction("" + id);
            model.BuildId = id;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new CommentService(userId, id);

            service.CreateComment(model, id);

            return RedirectToAction("../Build/");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var service = CreateCommentService(0);
            var detail = service.GetCommentById(id);
            service = CreateCommentService(detail.BuildId);
            var model =
                new CommentEdit
                {
                    BuildId = detail.BuildId,
                    UserId = detail.UserId,
                    Content = detail.Content
                };
            return View(model);
        }

        public ActionResult Details(int id, int BuildId)
        {
            var svc = CreateCommentService(BuildId);
            var model = svc.GetCommentById(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCommentService(0);

            if (service.UpdateComment(model))
            {
                TempData["SaveResult"] = "Your Comment was updated.";
                return RedirectToAction("../Build/Details/" + service._buildId.ToString());
            }

            ModelState.AddModelError("", "Your comment could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCommentService(0);
            int target = svc.GetCommentById(id).BuildId;
            svc.DeleteComment(id);
            TempData["SaveResult"] = "Your build was deleted";
            return RedirectToAction("../Build/Details/" + target.ToString());
        }
        private CommentService CreateCommentService(int buildId)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId,buildId);
            return service;
        }
    }
}