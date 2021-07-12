using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_portal.Areas.Admin.Controllers
{
    [Authorize(Roles = "Quản trị")]
    public class ReportManagementController : Controller
    {
        // GET: Admin/ReportManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}