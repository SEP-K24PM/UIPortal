using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portal.Constants;
using UI_portal.Models;
using UI_portal.Services;
using UI_portal.ViewModels;

namespace UI_portal.Controllers
{
    [Authorize]
    public class ThingController : Controller
    {
        ThingService thingService;
        CategoryService categoryService;
        private string userContextId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        // GET: List Thing
        public async Task<ActionResult> Index()
        {
            await getNotificationsAsync();
            thingService = new ThingService();
            List<Thing> list = await thingService.GetListThings(userContextId);
            return View(list);
        }
        
        public async Task<ActionResult> Details(string thingId)
        {
            await getNotificationsAsync();
            thingService = new ThingService();
            Thing thing = await thingService.GetThingDetails(thingId);
            Post post = await thingService.GetPostByThingId(thingId);
            ThingDetailsVM thingDetailsVM = new ThingDetailsVM
            {
                Thing = thing,
                Post = post
            };
            return View(thingDetailsVM);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            await getNotificationsAsync();
            categoryService = new CategoryService();
            List<Category> categories = await categoryService.GetCategories();
            ViewData["Categories"] = categories;
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(Thing thing, HttpPostedFileBase picture)
        {
            if(ModelState.IsValid)
            {
                thingService = new ThingService();
                thing.user_id = userContextId;
                thing.image = Guid.NewGuid().ToString() + ".png";
                Thing savedThing = await thingService.CreateThing(thing);
                if (picture != null)
                {
                    var path = Server.MapPath($"~/{ImageConstants.Thing}");
                    picture.SaveAs(path + thing.image);
                }
                return RedirectToAction("Details", new { thingId = savedThing.id });
            }
            categoryService = new CategoryService();
            List<Category> categories = await categoryService.GetCategories();
            ViewData["Categories"] = categories;
            return View(thing);
        }
        
        [HttpGet]
        public async Task<ActionResult> Update(string thingId)
        {
            await getNotificationsAsync();
            categoryService = new CategoryService();
            List<Category> categories = await categoryService.GetCategories();
            ViewData["Categories"] = categories;
            thingService = new ThingService();
            Thing thing = await thingService.GetThingDetails(thingId);
            return View(thing);
        }
        
        [HttpPost]
        public async Task<ActionResult> Update(string thingId, Thing thing, HttpPostedFileBase picture)
        {
            if(ModelState.IsValid)
            {
                thingService = new ThingService();
                thing.user_id = userContextId;
                Thing savedThing = await thingService.Update(thingId, thing);
                if (picture != null)
                {
                    var path = Server.MapPath($"~/{ImageConstants.Thing}");
                    System.IO.File.Delete(path + thing.image);
                    picture.SaveAs(path + thing.image);
                }
                return RedirectToAction("Details", new { thingId = thingId });
            }
            categoryService = new CategoryService();
            List<Category> categories = await categoryService.GetCategories();
            ViewData["Categories"] = categories;
            return View(thing);
        }
        
        [HttpPost]
        public async Task<ActionResult> Delete(string thingId)
        {
            thingService = new ThingService();
            Thing thing = await thingService.GetThingDetails(thingId);
            if(thing != null)
            {
                bool result = await thingService.Delete(thingId);
                if (result)
                {
                    var path = Server.MapPath($"~/{ImageConstants.Thing}");
                    System.IO.File.Delete(path + thing.image);
                }
            }
            return RedirectToAction("Index");
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