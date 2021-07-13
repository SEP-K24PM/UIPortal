using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portal.Services;

namespace UI_portal.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserService userService;
        // GET: Profile
        [HttpPost]
        public async Task<ActionResult> Index(string userId)
        {
            userService = new UserService();
            var user = await userService.getUserProfile(userId);

            return View();
        }

        public ActionResult Notification(string userId)
        {
            return View();
        }
    }
}
