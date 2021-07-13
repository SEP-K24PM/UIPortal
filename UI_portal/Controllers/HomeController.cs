using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;
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
            /*
            TradeService tradeService = new TradeService();
            PostRegistration postRegistration = new PostRegistration("đây là test accpet register", false, "5fad1a4e-e14f-4a7a-a85d-4c1c6547a9c7",
                "14551453-4e68-4e40-9aac-fda12a7b11bc", "3f552bf8-0bb7-4d5d-b1e2-179844bcd338");
            var result = await tradeService.getRegistration(postRegistration);
            ViewBag.Message = result;
            
            TradeService tradeService = new TradeService();
            var result = await tradeService.acceptRegister("b3d5b5a2-3165-42d7-8138-3ebcb6982a22");
            */
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}