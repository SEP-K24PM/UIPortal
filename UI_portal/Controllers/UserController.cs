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
        private string userContextId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        // GET: Profile
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Index(string userId)
        {
            await getNotificationsAsync();
            userService = new UserService();
            var user = await userService.getUserProfile(userId);
            double star = 0;
            if(user.userRatingList != null)
            {
                foreach (var item in user.userRatingList)
                {
                    star += item.rating;
                }
                star = star / user.userRatingList.Count;
            }
            ViewBag.Star = star.ToString("0.00");
            return View(user);
        }

        public async Task<ActionResult> History()
        {
            await getNotificationsAsync();
            var userService = new UserService();
            var user = await userService.getUserProfile(userContextId);
            var list = new List<Post>();
            if(user.postList != null)
            {
                list = user.postList
                .Where(p => p.deletion == false && p.visible == true)
                .OrderByDescending(p => p.created_time)
                .ToList();
            }
            return View(list);
        }

        public async Task<ActionResult> Registration()
        {
            var userService = new UserService();
            var regist = await userService.getUserRegist(userContextId);
            return View(regist);
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
