using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_portal.Areas.Admin.Controllers
{
    [Authorize(Roles = "Quản trị")]
    public class PostManagementController : Controller
    {
        // GET: Admin/PostManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}