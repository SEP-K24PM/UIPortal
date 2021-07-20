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
    public class NotificationController : Controller
    {
        // GET: Notification
        public async Task<ActionResult> Index()
        {
            await getNotificationsAsync();
            List<Notification> list = await getNotificationsAsync();
            return View(list);
        }

        public async Task<List<Notification>> getNotificationsAsync()
        {
            NotificationService notificationService = new NotificationService();
            List<Notification> listNoti = await notificationService
                    .GetNotificationsAsync(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return listNoti.OrderByDescending(n => n.time).ToList();
        }
    }
}