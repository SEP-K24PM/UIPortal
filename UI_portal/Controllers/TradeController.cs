using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public async Task<ActionResult> Register(string postId, string userId)
        {
            tradeService = new TradeService();
            PostRegistration postRegistrationModel = new PostRegistration();
            postRegistrationModel.post_id = postId; // "3f552bf8-0bb7-4d5d-b1e2-179844bcd338";
            postRegistrationModel.user_id = userId; //"14551453-4e68-4e40-9aac-fda12a7b11bc";
            var userIDforList = userId;
            var list = await tradeService.listThingUser(userIDforList);

            ViewData["listThing"] = list;
            ViewData["postRegis"] = postRegistrationModel;

            return View(postRegistrationModel);
        }

        public async Task SaveToDB(PostRegistration postRegistration)
        {
            tradeService = new TradeService();
            var registed = await tradeService.getRegistration(postRegistration);

        }
        [HttpGet]
        public async Task<ActionResult> makeSureAsync(string thingId, string userId,string postId)
         {
            PostRegistration passingPost = new PostRegistration();
            passingPost.thing_id = thingId;
            passingPost.user_id = userId;
            passingPost.post_id = postId;

            await SaveToDB(passingPost);
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