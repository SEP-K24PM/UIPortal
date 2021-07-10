using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;

namespace UI_portal.Controllers
{
    public class ReportController : Controller
    {
        [Authorize]
        [HttpPost]
        public ActionResult Create(Post_Report report)
        {
            return View();
        }
    }
}