using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UI_portal.Constants;
using UI_portal.Models;

namespace UI_portal.Services
{
    public class ReportService
    {
        public ReportService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<PostReport> Report(PostReport postReport)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(ReportApiConstants.REPORT);

            var convertedReport = JsonConvert.SerializeObject(postReport);
            request.Content = new StringContent(convertedReport, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            PostReport savedReport = new PostReport();
            if(response.Content != null)
            {
                savedReport = await response.Content.ReadAsAsync<PostReport>();
            }
            return savedReport;
        }
    }
}