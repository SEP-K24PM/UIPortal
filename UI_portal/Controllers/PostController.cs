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
            if (User.Identity.IsAuthenticated)
                await getNotificationsAsync();
            return View(post);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            thingService = new ThingService();
            var listThing = await thingService.GetListAvailableThings(userContextId);
            if (User.Identity.IsAuthenticated)
                await getNotificationsAsync();
            return View(listThing);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Post post)
        {
            postService = new PostService();
            if (ModelState.IsValid)
            {
                Post savedPost = await postService.CreatePost(post);
                return RedirectToAction("DetailsAsync", new { postId = savedPost.id });
            }
            thingService = new ThingService();
            var listThing = await thingService.GetListAvailableThings(userContextId);
            return View(listThing);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Update(string postId)
        {
            if (User.Identity.IsAuthenticated)
                await getNotificationsAsync();
            postService = new PostService();
            Post post = await postService.GetDetails(postId);
            if (post.status == "Mở")
                return View(post);
            return RedirectToAction("DetailsAsync", new { postId });
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Update(string postId, Post post)
        {
            postService = new PostService();
            if (ModelState.IsValid)
            {
                post.id = postId;
                Post savedPost = await postService.UpdatePost(post);
                return RedirectToAction("DetailsAsync", new { postId = postId });
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Delete(string postId)
        {
            postService = new PostService();
            Post post = await postService.GetDetails(postId);
            if (post.status == "Mở")
            {
                await postService.DeletePost(postId);
                return RedirectToAction("Index", "Newsfeed");
            }
            return RedirectToAction("DetailsAsync", new { postId });
        }

        [HttpPost]
        public async Task<JsonResult> Search(string search)
        {
            if (search != null)
            {
                postService = new PostService();
                List<PostElastic> result = await postService.SearchPost(search);
                List<PostElastic> visibleResult = result.Where(p => p.visible == true).ToList();
                return  Json(new { success = true, list = result }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> SearchPost(string search, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                await getNotificationsAsync();
            postService = new PostService();
            if (search != null)
            {
                List<PostElastic> result = await postService.SearchPost(search);
                List<PostElastic> visibleResult = result.Where(p => p.visible == true).ToList();
                 return View(visibleResult);
            }
            return RedirectToRoute(returnUrl);
        }

        public async Task getNotificationsAsync()
        {
            NotificationService notificationService = new NotificationService();
            List<Notification> listNoti = await notificationService
                    .GetNotificationsAsync(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewData["notification"] = listNoti.OrderByDescending(n => n.time).ToList();
        }
    }
}