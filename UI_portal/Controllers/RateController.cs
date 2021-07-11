using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;

namespace UI_portal.Controllers
{
    public class RateController : Controller
    {
        [Authorize]
        [HttpPost]
        public ActionResult Create(UserRating userRating)
        {
            return View();
        }
    }
}