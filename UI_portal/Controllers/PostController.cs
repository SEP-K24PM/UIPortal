using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
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
            if (User.Identity.IsAuthenticated)
                await getNotificationsAsync();
            postService = new PostService();
            tradeService = new TradeService();
            List<PostRegistration> postRegistrations = await tradeService.GetListPostRegistrations(postId);
            Post post = await postService.GetDetails(postId);

            post.postRegistrationList = postRegistrations;
            if (post.thing != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (userContextId == post.thing.userAccount.id)
                        ViewData["AbleToModifyPost"] = "true";
                    else
                        ViewData["AbleToModifyPost"] = "false";
                }
            }
            else
            {
                var thing = new Thing();
                thing.category = new Category();
                thing.userAccount = new UserAccount();
                post.thing = thing;
            }
            return View(post);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            await getNotificationsAsync();
            thingService = new ThingService();
            var listThing = await thingService.GetListAvailableThings(userContextId);
            return View(listThing);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
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
            return RedirectToAction("Create");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Update(string postId)
        {
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
            return RedirectToAction("Update", new { postId = postId });
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
            return RedirectToAction("DetailsAsync", new { postId = postId });
        }

        [HttpPost]
        public async Task<JsonResult> Search(string search)
        {
            if (search != null)
            {
                postService = new PostService();
                List<PostElastic> result = await postService.SearchPost(search);
                List<PostElastic> visibleResult = new List<PostElastic>();
                if (result != null)
                {
                    visibleResult = result.Where(p => p.visible == true).ToList();
                }
                return Json(new { success = true, list = visibleResult }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> SearchPost(string search, string returnUrl, int? page = 1)
        {
            if (User.Identity.IsAuthenticated)
                await getNotificationsAsync();
            postService = new PostService();
            if (search != null)
            {
                List<PostElastic> result = await postService.SearchPost(search);
                List<PostElastic> visibleResult = new List<PostElastic>();
                if (result != null)
                {
                    visibleResult = result.Where(p => p.visible == true).ToList();
                }
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(visibleResult.ToPagedList(pageNumber, pageSize));
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

        public async Task<JsonResult> CancelPost(string postId)
        {
            postService = new PostService();
            Post post = await postService.CancelPost(postId);
            if (post != null)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CompletePost(string postId)
        {
            postService = new PostService();
            Post post = await postService.CompletePost(postId, userContextId);
            return RedirectToAction("History", "User");
        }
    }
}