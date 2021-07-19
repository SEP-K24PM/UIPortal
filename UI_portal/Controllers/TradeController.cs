using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;
using UI_portal.Services;

namespace UI_portal.Controllers
{
    [Authorize]
    public class TradeController : Controller
    {
        private TradeService tradeService;
        [HttpGet]
        public async Task<ActionResult> Register(string postId, string userId)
        {
            tradeService = new TradeService();
            PostRegistration postRegistrationModel = new PostRegistration();
            postRegistrationModel.post_id = postId; // "3f552bf8-0bb7-4d5d-b1e2-179844bcd338";
            postRegistrationModel.user_id = userId; //"14551453-4e68-4e40-9aac-fda12a7b11bc";
            var userIDforList = userId;
            var list = await tradeService.listThingUser(userIDforList);

            ViewData["listThing"] = list;
            ViewData["postRegis"] = postRegistrationModel;

            return View(postRegistrationModel);
        }
        //trade với món đồ 
        [HttpPost]
        public async Task<ActionResult> Register(string userId, string postId, string thingId, string comm)
        {
            var model = new PostRegistration();
            model.post_id = postId;
            model.user_id = userId;
            model.thing_id = thingId;
            model.description = comm;

            tradeService = new TradeService();
            var registed = await tradeService.getRegistration(model);
            return View("Index");
        }
        //trade với free
        [HttpGet]
        public ActionResult RegisterFree(string postId, string userId)
        {
            tradeService = new TradeService();
            PostRegistration postRegistrationModel = new PostRegistration();
            postRegistrationModel.post_id = "3f552bf8-0bb7-4d5d-b1e2-179844bcd338"; // "3f552bf8-0bb7-4d5d-b1e2-179844bcd338";
            postRegistrationModel.user_id = "14551453-4e68-4e40-9aac-fda12a7b11bc"; //"14551453-4e68-4e40-9aac-fda12a7b11bc";
            ViewData["postRegis"] = postRegistrationModel;

            return View(postRegistrationModel);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterFree(string userId, string postId, string comm)
        {
            var model = new PostRegistration();
            model.post_id = postId;
            model.user_id = userId;
            model.description = comm;

            tradeService = new TradeService();
            var registed = await tradeService.getRegistration(model);
            return View("Index");
        }

        public async Task<ActionResult> AcceptRegister(string registerPostId)
        {
            tradeService = new TradeService();
            var acceptRegister = await tradeService.acceptRegister(registerPostId);

            return View();
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