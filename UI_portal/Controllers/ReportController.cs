using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;

namespace UI_portal.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        [HttpGet]
        public ActionResult Create(string postId)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(PostReport report)
        {
            return View();
        }
    }
}