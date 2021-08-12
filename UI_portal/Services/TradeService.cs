using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UI_portal.Models;
using UI_portal.Constants;
using Newtonsoft.Json;
using System.Text;

namespace UI_portal.Services
{
    public class TradeService
    {
        HttpClient _client = new HttpClient();
        public TradeService()
        {
        }

        public async Task<PostRegistration> registerPots(PostRegistration postRegistration)
        {
            var postRegistrationStatus = new PostRegistration();
            try
            {
                var convertedPost = JsonConvert.SerializeObject(postRegistration);

                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;

                request.RequestUri = new Uri(TradeApiConstants.REGISTER);
                request.Content = new StringContent(convertedPost, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.SendAsync(request);

                postRegistrationStatus = await response.Content.ReadAsAsync<PostRegistration>();
            }
            catch (Exception e) { Console.Write(e); }
            return postRegistrationStatus;
        }

        public async Task<Post> acceptRegister(string postRegisID)
        {
            var post = new Post();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(TradeApiConstants.ACCEPT_REGISTRATION + postRegisID);

                HttpResponseMessage response = await _client.SendAsync(request);

                post = await response.Content.ReadAsAsync<Post>();
            }
            catch (Exception e) { Console.Write(e); }
            return post;
        }

        public async Task<List<Thing>> listThingUser(string UserID)
        {
            var list = new List<Thing>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(ThingApiConstants.LIST_AVAILABLE + UserID);

                HttpResponseMessage response = await _client.SendAsync(request);
                list = await response.Content.ReadAsAsync<List<Thing>>();
            }
            catch (Exception e) { Console.Write(e); }
            return list;
        }

        public async Task<List<PostRegistration>> GetListPostRegistrations(string postId)
        {
            var list = new List<PostRegistration>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(TradeApiConstants.LIST_REGISTRATION + postId);

                HttpResponseMessage response = await _client.GetAsync(TradeApiConstants.LIST_REGISTRATION + postId);

                list = await response.Content.ReadAsAsync<List<PostRegistration>>();
            }
            catch (Exception e) { Console.Write(e); }
            return list;
        }
    }
}