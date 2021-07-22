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
    public class ReportController : Controller
    {
        private ReportService reportService;

        [HttpPost]
        public async Task<ActionResult> Create(PostReport report)
        {
            if(ModelState.IsValid)
            {
                reportService = new ReportService();
                PostReport savedReport = await reportService.Report(report);
            }
            return RedirectToAction("DetailsAsync", "Post", new { postId = report.post_id });
        }
    }
}