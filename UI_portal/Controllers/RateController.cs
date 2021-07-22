using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class RateController : Controller
    {
        private PostService postService;
        private RateService rateService;
        private TradeService tradeService;
        private string userContextId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        [HttpGet]
        public async Task<ActionResult> Create(string postId)
        {
            postService = new PostService();
            tradeService = new TradeService();
            rateService = new RateService();

            Post post = await postService.GetDetails(postId);
            List<PostRegistration> postRegistrations = await tradeService.GetListPostRegistrations(postId);
            PostRegistration approved = postRegistrations.Where(p => p.chosen == true).SingleOrDefault();
            List<UserRating> userRatings = await rateService.getRatingsByPost(postId);

            ViewBag.PostRegistration = approved;

            if (userRatings.Count == 2)
            {
                ViewBag.Message = "Bạn đã đánh giá rồi";
                return View();
            }
            if(userRatings.Count == 1)
            {
                if(userRatings[0].rater_id == userContextId)
                {
                    ViewBag.Message = "Bạn đã đánh giá rồi";
                    return View();
                }
            }
            UserRatingVM userRatingVM = new UserRatingVM
            {
                Post_id = post.id,
                Rater = userContextId,
                Rated = approved.userAccount.id
            };
            return View(userRatingVM);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserRatingVM userRatingVM)
        {
            if(ModelState.IsValid)
            {
                UserRating userRating = new UserRating
                {
                    description = userRatingVM.Description,
                    rating = userRatingVM.Rating,
                    post_id = userRatingVM.Post_id,
                    rated_user_id = userRatingVM.Rated,
                    rater_id = userRatingVM.Rater
                };
                rateService = new RateService();
                UserRating savedRating = await rateService.Rating(userRating);
                return RedirectToAction("Index", "User", new { userId  = savedRating.rated_user_id });
            }
            return View(userRatingVM);
        }

        [HttpGet]
        public async Task<ActionResult> CreateFromRegistration(string postId)
        {
            postService = new PostService();
            tradeService = new TradeService();
            rateService = new RateService();

            Post post = await postService.GetDetails(postId);
            List<PostRegistration> postRegistrations = await tradeService.GetListPostRegistrations(postId);
            List<UserRating> userRatings = await rateService.getRatingsByPost(postId);

            ViewBag.Post = post;

            if (userRatings.Count == 2)
            {
                ViewBag.Message = "Bạn đã đánh giá rồi";
                return View();
            }
            if (userRatings.Count == 1)
            {
                if (userRatings[0].rater_id == userContextId)
                {
                    ViewBag.Message = "Bạn đã đánh giá rồi";
                    return View();
                }
            }
            UserRatingVM userRatingVM = new UserRatingVM
            {
                Post_id = post.id,
                Rater = userContextId,
                Rated = post.thing.userAccount.id
            };
            return View(userRatingVM);
        }
    }
}