using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_portal.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class HomeManagerController : Controller
    {
        // GET: Manager/HomeManager
        public ActionResult Index()
        {
            return View();
        }
    }
}