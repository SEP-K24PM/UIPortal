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
    public class ThingController : Controller
    {
        ThingService thingService;
        private string userContextId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        // GET: List Thing
        public async Task<ActionResult> Index()
        {
            thingService = new ThingService();
            List<Thing> list = await thingService.GetListThings(userContextId);
            return View(list);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Thing thing)
        {
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Update(string thingId)
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Update(string thingId, Thing thing)
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Delete(string thingId)
        {
            return RedirectToAction("Index");
        }
    }
}