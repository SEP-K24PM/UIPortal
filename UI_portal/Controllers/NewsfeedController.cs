using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_portal.Controllers
{
    public class NewsfeedController : Controller
    {
        // GET: Newsfeed
        public ActionResult Index()
        {
            return View();
        }
    }
}