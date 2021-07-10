using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;

namespace UI_portal.Controllers
{
    [Authorize]
    public class TradeController : Controller
    {
        [HttpPost]
        public ActionResult RegisterPost(string postId, Post_Registration postRegistration)
        {
            return View();
        }

        public ActionResult ApproveRegister(string registerPostId)
        {
            return View();
        }
    }
}