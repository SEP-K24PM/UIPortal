﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portalAdmin.Models;
using UI_portalAdmin.Services;
using PagedList;

namespace UI_portalAdmin.Controllers
{
    [Authorize(Roles = "Quản trị viên")]
    public class UserManagementController : Controller
    {
        private UserService _userService = new UserService();

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
        public async Task<ActionResult> BlockUser(UserAccount user)
        {
            //user.block = isBlock;
            await _userService.BlockUser(user);
            return RedirectToAction("Index");
        }
    }
}