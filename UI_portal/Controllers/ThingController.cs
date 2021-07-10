using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;

namespace UI_portal.Controllers
{
    public class ThingController : Controller
    {
        // GET: List Thing
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Thing thing)
        {
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Update(string thingId)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Update(string thingId, Thing thing)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(string thingId)
        {
            return RedirectToAction("Index");
        }
    }
}