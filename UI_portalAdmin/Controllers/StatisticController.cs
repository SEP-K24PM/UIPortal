using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portalAdmin.Models;
using UI_portalAdmin.Services;

namespace UI_portalAdmin.Controllers
{
    [Authorize(Roles = "Quản lý")]
    public class StatisticController : Controller
    {
        private StatisticService _statisticService;
        // GET: Statistic
        public async Task<ActionResult> Index()
        {
            _statisticService = new StatisticService();
            List<Category> category = await _statisticService.GetCategoryStatistic();
            return View(category);
        }

        public async Task<ActionResult> StatisticPost()
        {
            _statisticService = new StatisticService();
            List<Post> post = await _statisticService.GetPostStatistic();
            return View(post);
        }

    }
}
