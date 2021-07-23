using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UI_portalAdmin.Constants;
using UI_portalAdmin.Models;

namespace UI_portalAdmin.Services
{
    public class ReportService
    {
        public ReportService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<List<PostReport>> GetListReports()
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(AdminApiConstants.REPORT_LIST);

            HttpResponseMessage response = await _client.SendAsync(request);

            List<PostReport> reports = await response.Content.ReadAsAsync<List<PostReport>>();
            return reports;
        }

        public async Task<PostReport> GetReport(string reportId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(AdminApiConstants.REPORT_DETAILS + reportId);

            HttpResponseMessage response = await _client.SendAsync(request);

            PostReport report = await response.Content.ReadAsAsync<PostReport>();
            return report;
        }

        public async Task HandleReport(PostReport report)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(AdminApiConstants.REPORT_HANDLE);

            var convertedReport = JsonConvert.SerializeObject(report);
            request.Content = new StringContent(convertedReport, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);
        }
    }
}