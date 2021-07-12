using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_portal.Controllers
{
    public class UserController : Controller
    {
        // GET: Profile
        public ActionResult Index(string userId)
        {

            return View();
        }

        public ActionResult Notification()
        {
            return View();
        }
    }
}
