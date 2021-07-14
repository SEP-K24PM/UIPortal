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

namespace UI_portal.Controllers
{
    public class PostController : Controller
    {
        private PostService postService;
        private TradeService tradeService;
        private ThingService thingService;
        private string userContextId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        public async Task<ActionResult> DetailsAsync(string postId)
        {
            postService = new PostService();
            tradeService = new TradeService();
            List<PostRegistration> postRegistrations = await tradeService.GetListPostRegistrations(postId);
            Post post = await postService.GetDetails(postId);
            post.postRegistrationList = postRegistrations;
            if (User.Identity.IsAuthenticated)
            {
                if (userContextId == post.thing.userAccount.id)
                    ViewData["AbleToModifyPost"] = "true";
                else
                    ViewData["AbleToModifyPost"] = "false";
            }
            return View(post);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            thingService = new ThingService();
            var listThing = await thingService.GetListThings(userContextId);
            return View(listThing);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Post post)
        {
            postService = new PostService();
            if(ModelState.IsValid)
            {
                Post savedPost = await postService.CreatePost(post);
                return RedirectToAction("Details", new { postId = savedPost.id });
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Update(string postId)
        {
            postService = new PostService();
            Post post = await postService.GetDetails(postId);
            return View(post);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Update(string postId, Post post)
        {
            postService = new PostService();
            if (ModelState.IsValid)
            {
                Post savedPost = await postService.UpdatePost(post);
                return RedirectToAction("Details", new { postId = savedPost.id });
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Delete(string postId)
        {
            postService = new PostService();
            await postService.DeletePost(postId);
            return RedirectToAction("Index", "Newsfeed");
        }

        [HttpPost]
        public async Task<JsonResult> Search(string search)
        {
            if(search != null)
            {
                List<Post> result = await postService.SearchPost(search);
                return Json(new { success = true, list = result }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> SearchPost(string search, string returnUrl)
        {
            postService = new PostService();
            if (search != null)
            {
                List<Post> result = await postService.SearchPost(search);
                return View(result);
            }
            return RedirectToRoute(returnUrl);
        }
    }
}