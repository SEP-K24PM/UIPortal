using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI_portalAdmin.Models;
using UI_portalAdmin.Services;
using PagedList;
using Microsoft.AspNet.Identity;

namespace UI_portalAdmin.Controllers
{
    [Authorize(Roles = "Quản trị viên")]
    public class ReportManagementController : Controller
    {
        ReportService _reportService = new ReportService();
        PostService _postService = new PostService();
        private string userContextId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        // GET: ReportManagement
        public async Task<ActionResult> Index(int? page = 1)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<PostReport> listReports = await _reportService.GetListReports();
            return View(listReports.ToPagedList(pageNumber, pageSize));
        }

        // GET: ReportManagement/Details/5
        public async Task<ActionResult> Details(string reportId)
        {
            var report = await _reportService.GetReport(reportId);
            var post = report == null ? new Post() : await _postService.GetDetails(report.post.id);
            report.post = post;
            if(post == null)
            {
                var thing = new Thing();
                thing.userAccount = new UserAccount();
                post.thing = thing;
            }
            return View(report);
        }

        [HttpPost]
        public async Task<ActionResult> HandleReport(PostReport postReport)
        {
            var report = new PostReport
            {
                id = postReport.id,
                description = postReport.description,
                handling = postReport.handling,
                reason_by_admin = postReport.reason_by_admin,
                admin = new AdminAccount
                {
                    id = userContextId
                },
                post = new Post
                {
                    id = postReport.post_id
                },
                reporter = new UserAccount
                {
                    id = postReport.reporter_id
                }
            };

            await _reportService.HandleReport(report);
            return RedirectToAction("Details", new { reportId = report.id });
        }
       
    }
}
