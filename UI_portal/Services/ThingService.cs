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
    public class ThingService
    {
        public ThingService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<List<Thing>> GetListThings(string userId)
        {
            var list = new List<Thing>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(ThingApiConstants.LIST_BY_USER + userId);

                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.Content != null)
                {
                    list = await response.Content.ReadAsAsync<List<Thing>>();
                }
            }
            catch (Exception e) { Console.Write(e); }
            return list;
        }

        public async Task<List<Thing>> GetListAvailableThings(string userId)
        {
            var list = new List<Thing>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(ThingApiConstants.LIST_AVAILABLE + userId);

                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.Content != null)
                {
                    list = await response.Content.ReadAsAsync<List<Thing>>();
                }
            }
            catch (Exception e) { Console.Write(e); }
            return list;
        }

        public async Task<Thing> GetThingDetails(string thingId)
        {
            var thing = new Thing();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(ThingApiConstants.DETAILS + thingId);

                HttpResponseMessage response = await _client.SendAsync(request);

                thing = await response.Content.ReadAsAsync<Thing>();
            }
            catch (Exception e) { Console.Write(e); }
            return thing;
        }
        public async Task<Post> GetPostByThingId(string thingId)
        {
            var post = new Post();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(ThingApiConstants.POST + thingId);

                HttpResponseMessage response = await _client.SendAsync(request);
                if (response.Content != null)
                {
                    post = await response.Content.ReadAsAsync<Post>();
                }
            }
            catch (Exception e) { Console.Write(e); }
            return post;
        }

        public async Task<Thing> CreateThing(Thing thing)
        {
            Thing savedThing = new Thing();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(ThingApiConstants.ADD);

                var convertedThing = JsonConvert.SerializeObject(thing);
                request.Content = new StringContent(convertedThing, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.SendAsync(request);

                savedThing = await response.Content.ReadAsAsync<Thing>();
            }
            catch (Exception e) { Console.Write(e); }
            return savedThing;
        }

        public async Task<Thing> Update(string thingId, Thing thing)
        {
            Thing savedThing = new Thing();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(ThingApiConstants.UPDATE + thingId);

                var convertedThing = JsonConvert.SerializeObject(thing);
                request.Content = new StringContent(convertedThing, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.SendAsync(request);

                savedThing = await response.Content.ReadAsAsync<Thing>();
            }
            catch (Exception e) { Console.Write(e); }
            return savedThing;
        }

        public async Task<bool> Delete(string thingId)
        {
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(ThingApiConstants.DELETE + thingId);

                HttpResponseMessage response = await _client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }
            }
            catch (Exception e) { Console.Write(e); }
            return false;
        }
    }
}