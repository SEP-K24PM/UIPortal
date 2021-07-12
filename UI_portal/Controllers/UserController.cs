using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_portal.Services;

namespace UI_portal.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;
        // GET: Profile
        public ActionResult Index(string userId)
        {

            return View();
        }

        public ActionResult Notification(string userId)
        {
            return View();
        }
    }
}
