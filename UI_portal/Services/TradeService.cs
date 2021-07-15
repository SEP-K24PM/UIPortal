using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using UI_portal.Constants;
using UI_portal.Models;

namespace UI_portal.Services
{
    public class TradeService
    {
        HttpClient _client = new HttpClient();
        public TradeService()
        {

        }

        public async Task<List<PostRegistration>> GetListPostRegistrations(string postId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(TradeApiConstants.LIST_REGISTRATION + postId);

            HttpResponseMessage response = await _client.GetAsync(TradeApiConstants.LIST_REGISTRATION + postId);

            var list = await response.Content.ReadAsAsync<List<PostRegistration>>();
            return list;
        }
    }
}