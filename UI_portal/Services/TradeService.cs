using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using UI_portal.Models;
using UI_portal.Constants;
using Newtonsoft.Json;
using System.Text;

namespace UI_portal.Services
{
    public class TradeService
    {
        public TradeService()
        {

        }
        HttpClient _client = new HttpClient();

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

    }
}