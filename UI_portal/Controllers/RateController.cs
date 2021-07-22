using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class RateController : Controller
    {
        private PostService postService;
        private RateService rateService;
        private string userContextId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        public async Task<ActionResult> Create(string postId)
        {
            postService = new PostService();
            Post post = await postService.GetDetails(postId);
            ViewBag.Post = post;
            if (post.thing.userAccount.id == userContextId)
            {
                if(post.giver != null)
                {
                    ViewBag.Message = "Bạn đã đánh giá rồi";
                    return View();
                }
            }
            else
            {
                if(post.given != null)
                {
                    ViewBag.Message = "Bạn đã đánh giá rồi";
                    return View();
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserRating userRating)
        {
            if(ModelState.IsValid)
            {
                rateService = new RateService();
                UserRating savedRating = await rateService.Rating(userRating);
                return RedirectToAction("Index", "User", new { userId  = savedRating.rated_user_id });
            }
            return View(userRating);
        }

    }
}