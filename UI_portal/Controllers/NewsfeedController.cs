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
    public class NewsfeedController : Controller
    {
        private PostService _postService = new PostService();
        // GET: Newsfeed
        public async Task<ActionResult> Index()
        {
            List<Post> model = await _postService.getNewsfeed();
            return View(model);
        }
    }
}