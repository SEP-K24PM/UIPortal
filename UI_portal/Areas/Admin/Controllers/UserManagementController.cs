using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_portal.Areas.Admin.Controllers
{
    [Authorize(Roles = "Quản trị")]
    public class UserManagementController : Controller
    {
        // GET: Admin/UserManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}