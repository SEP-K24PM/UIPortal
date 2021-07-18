using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;
using UI_portal.Services;
using PagedList;
using Microsoft.AspNet.Identity;

namespace UI_portal.Controllers
{
    public class NewsfeedController : Controller
    {
        private PostService _postService = new PostService();
        private NotificationService notificationService = new NotificationService();
        // GET: Newsfeed
        public async Task<ActionResult> Index(int? page = 1)
        {
            List<Post> list = await _postService.GetNewsfeed();
            int pageSize = 21;
            int pageNumber = (page ?? 1);
            ViewBag.ReturnUrl = Request.Url.AbsoluteUri;
            if (User.Identity.IsAuthenticated)
                await getNotificationsAsync();
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        public async Task getNotificationsAsync()
        {
            List<Notification> listNoti = await notificationService
                .GetNotificationsAsync(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewData["notification"] = listNoti.OrderByDescending(n => n.time).ToList();
        }
    }
}