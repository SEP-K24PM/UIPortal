using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_portal.Areas.Manager.Controllers
{
    [Authorize(Roles = "Quản lý")]
    public class StatisticController : Controller
    {
        // GET: Manager/Staitstic
        public ActionResult Index()
        {
            return View();
        }
    }
}