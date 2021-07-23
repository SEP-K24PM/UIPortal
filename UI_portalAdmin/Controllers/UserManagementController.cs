using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portalAdmin.Models;
using UI_portalAdmin.Services;
using PagedList;
using Microsoft.AspNet.Identity;

namespace UI_portalAdmin.Controllers
{
    [Authorize(Roles = "Quản trị viên")]
    public class UserManagementController : Controller
    {
        private UserService _userService = new UserService();
        private string userContextId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        // GET: userlist
        public async Task<ActionResult> Index(int? page = 1)
        {
            List<UserAccount> users = await _userService.GetUsers();
            users = users.OrderBy(u => u.email).ToList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.ReturnUrl = Request.Url.AbsoluteUri;
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public async Task<ActionResult> BlockUser(UserHandling userHandling)
        {
            userHandling.admin_id = userContextId;
            await _userService.BlockUser(userHandling);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetUser(string userId)
        {
            UserAccount user = await _userService.GetUser(userId);
            var list = user.userHandlingList.OrderByDescending(u => u.time).ToList();
            user.userHandlingList = list;
            return View(user);
        }
    }
}
