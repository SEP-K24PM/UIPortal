using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;

namespace UI_portal.Controllers
{
    public class PostController : Controller
    {

        public ActionResult Details(string postId)
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Post post)
        {
            return RedirectToAction("Details", new { postId = post.id });
        }

        [Authorize]
        [HttpGet]
        public ActionResult Update(string postId)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Update(string postId, Post post)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(string postId)
        {
            return RedirectToAction("Index", "Newsfeed");
        }

        [HttpPost]
        public JsonResult Search(string search)
        {
            return new JsonResult();
        }

        [HttpPost]
        public ActionResult SearchPost(string search)
        {
            return View();
        }
    }
}