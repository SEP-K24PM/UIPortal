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
    public class ThingService
    {
        public ThingService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<List<Thing>> GetListThings(string userId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(ThingApiConstants.LIST_BY_USER + userId);

            HttpResponseMessage response = await _client.SendAsync(request);

            var list = await response.Content.ReadAsAsync<List<Thing>>();
            return list;
        }

    }
}