using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portal.Services;

namespace UI_portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";
            AccountService accountService = new AccountService();
            accountService.sendEmailData("aaa@vanlanguni.vn");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}