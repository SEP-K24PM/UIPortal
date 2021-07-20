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

        public async Task<List<Thing>> GetListAvailableThings(string userId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(ThingApiConstants.LIST_AVAILABLE + userId);

            HttpResponseMessage response = await _client.SendAsync(request);

            var list = await response.Content.ReadAsAsync<List<Thing>>();
            return list;
        }

        public async Task<Thing> GetThingDetails(string thingId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(ThingApiConstants.DETAILS + thingId);

            HttpResponseMessage response = await _client.SendAsync(request);

            var thing = await response.Content.ReadAsAsync<Thing>();
            return thing;
        }
        public async Task<Post> GetPostByThingId(string thingId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(ThingApiConstants.POST + thingId);

            HttpResponseMessage response = await _client.SendAsync(request);
            var post = new Post();
            if(response.Content != null)
            {
                post = await response.Content.ReadAsAsync<Post>();
            }
            return post;
        }

    }
}