using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using UI_portalAdmin.Constants;
using UI_portalAdmin.Models;

namespace UI_portalAdmin.Services
{
    public class StatisticService
    {
        HttpClient _client = new HttpClient();

        public StatisticService()
        {

        }

        public async Task<List<Post>> GetPostStatistic()
        {
            var post = new List<Post>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(ManagerApiConstants.STATISTIC_POST);

                HttpResponseMessage response = await _client.SendAsync(request);

                post = await response.Content.ReadAsAsync<List<Post>>();
            }
            catch (Exception e) { Console.Write(e); }
            return post;
        }

        public async Task<List<Category>> GetCategoryStatistic()
        {
            var category = new List<Category>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(ManagerApiConstants.STATISTIC_CATEGORY);

                HttpResponseMessage response = await _client.SendAsync(request);

                category = await response.Content.ReadAsAsync<List<Category>>();
            }
            catch (Exception e) { Console.Write(e); }
            return category;
        }
    }
}