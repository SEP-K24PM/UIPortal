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
            userService = new UserService();
            var user = await userService.getUserProfile(userId);
            var userListPosted = await userService.getUserPosted(userId);
            var userListRated = await userService.getUserRated(userId);

            ViewData["ListRate"] = userListRated;
            ViewData["ListPost"] = userListPosted;
            ViewData["user"] = user;
            return View();
        }

        public ActionResult Notification(string userId)
        {
            return View();
        }
    }
}
