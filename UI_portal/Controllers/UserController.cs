using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;
using UI_portal.Services;
using Microsoft.AspNet.Identity;

namespace UI_portal.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserService userService;
        // GET: Profile
        [HttpGet]
        public async Task<ActionResult> Index(string userId)
        {
            if (User.Identity.IsAuthenticated)
                await getNotificationsAsync();
            userService = new UserService();
            var user = await userService.getUserProfile(userId);
            double star = 0;
            foreach (var item in user.userRatingList)
            {
                star += item.rating;
            }
            star = star / user.userRatingList.Count;
            ViewBag.Star = star.ToString("0.00");
            return View(user);
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
