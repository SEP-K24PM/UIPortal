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

       [HttpPost]
        public async Task<ActionResult> Register(string postId, PostRegistration postRegistration)
        {
            tradeService = new TradeService();
            var registed = await tradeService.getRegistration(postRegistration);

            return View();
        }

        public async Task<ActionResult> AcceptRegister(string registerPostId)
        {
            tradeService = new TradeService();
            var acceptRegister = await tradeService.acceptRegister(registerPostId);

            return View();
        }
    }
}