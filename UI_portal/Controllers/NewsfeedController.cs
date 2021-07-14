﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portal.Models;
using UI_portal.Services;
using PagedList;

namespace UI_portal.Controllers
{
    public class NewsfeedController : Controller
    {
        private PostService _postService = new PostService();
        // GET: Newsfeed
        public async Task<ActionResult> Index(int? page = 1)
        {
            List<Post> list = await _postService.getNewsfeed();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
    }
}