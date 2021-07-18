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

        public async Task<PostRegistration> getRegistration(PostRegistration postRegistration)
        {
            var convertedPost = JsonConvert.SerializeObject(postRegistration);

            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;

            request.RequestUri = new Uri(TradeApiConstants.REGISTER);
            request.Content = new StringContent(convertedPost, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            var PostRegistrationStatus = await response.Content.ReadAsAsync<PostRegistration>();
            return PostRegistrationStatus;
        }

        public async Task<PostRegistration> acceptRegister(string postRegisID)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(TradeApiConstants.ACCEPT_REGISTRATION + postRegisID);

            HttpResponseMessage response = await _client.SendAsync(request);

            var PostRegistrationStatus = await response.Content.ReadAsAsync<PostRegistration>();
            return PostRegistrationStatus;
        }
        
        public async Task<List<Thing>> listThingUser(string UserID)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(TradeApiConstants.SHOW_LIST_THING_USER + UserID);

            HttpResponseMessage response = await _client.SendAsync(request);
            List<Thing> list = await response.Content.ReadAsAsync<List<Thing>>();

            return list;
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