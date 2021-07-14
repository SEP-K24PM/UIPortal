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
    [Authorize]
    public class TradeController : Controller
    {
        private TradeService tradeService;

        [HttpGet]
        public ActionResult Register(string postId, string userId)
        {
            PostRegistration postRegistrationModel = new PostRegistration();
            postRegistrationModel.post_id = "3f552bf8-0bb7-4d5d-b1e2-179844bcd338";
            postRegistrationModel.user_id = "14551453-4e68-4e40-9aac-fda12a7b11bc";
            return View(postRegistrationModel);
        }

        [HttpPost]
        public async Task<ActionResult> Register(PostRegistration postRegistration)
        {
            tradeService = new TradeService();
            var registed = await tradeService.getRegistration(postRegistration);

            return View("Index");
        }
    
        public async Task<ActionResult> AcceptRegister(string registerPostId)
        {
            tradeService = new TradeService();
            var acceptRegister = await tradeService.acceptRegister(registerPostId);

            return View();
        }
    }
}