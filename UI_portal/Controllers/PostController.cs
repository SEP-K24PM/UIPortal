using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;
using UI_portal.Services;
using UI_portal.ViewModels;

namespace UI_portal.Controllers
{
    public class PostController : Controller
    {
        private PostService postService;
        private TradeService tradeService;

        public async Task<ActionResult> DetailsAsync(string postId)
        {
            postService = new PostService();
            tradeService = new TradeService();
            List<PostRegistration> postRegistrations = await tradeService.GetListPostRegistrations(postId);
            Post post = await postService.getDetails(postId);
            post.postRegistrationList = postRegistrations;
            if (User.Identity.IsAuthenticated)
            {
                string userContextId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                if (userContextId == post.thing.userAccount.id)
                    ViewData["AbleToModifyPost"] = "true";
                else
                    ViewData["AbleToModifyPost"] = "false";
            }
            return View(post);
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