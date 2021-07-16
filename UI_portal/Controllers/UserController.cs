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
    public class UserController : Controller
    {
        private UserService userService;
        // GET: Profile
        [HttpGet]
        public async Task<ActionResult> Index(string userId)
        {
            userId = "7e74f24b-2ac2-4867-b39a-644b55cd11ed";
            userService = new UserService();
            var user = await userService.getUserProfile(userId);

            ViewData["user"] = user;
            return View(user);
        }

        public ActionResult Notification(string userId)
        {
            return View();
        }
    }
}
