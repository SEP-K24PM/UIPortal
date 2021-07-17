using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portalAdmin.Models;
using UI_portalAdmin.Services;

namespace UI_portalAdmin.Controllers
{
    [Authorize(Roles = "Quản trị viên")]
    public class UserManagementController : Controller
    {
        private UserService _userService = new UserService();

        // GET: userlist
        public async Task<ActionResult> IndexAsync()
        {
            List<UserAccount> users = await _userService.GetUsers();
            return View(users);
        }

        [HttpPost]
        public async Task<ActionResult> BlockUser(UserAccount user)
        {
            await _userService.BlockUser(user);
            return RedirectToAction("Index");
        }
    }
}
