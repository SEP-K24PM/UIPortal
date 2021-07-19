using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using UI_portal.Models;
using UI_portal.Constants;
using Newtonsoft.Json;

namespace UI_portal.Services
{
    public class UserService
    {
        public UserService()
        {

        }
        HttpClient _client = new HttpClient();


       
        public async Task<UserAccount> getUserProfile(string userID)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(UserApiConstants.getProfile + userID);

            HttpResponseMessage response = await _client.SendAsync(request);

            var profile = await response.Content.ReadAsAsync<UserAccount>();
            return profile;
        }
        public async Task<List<Post>> getUserPosted(string userID)
        {

            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(UserApiConstants.getProfile + userID + "/post");

            HttpResponseMessage response = await _client.SendAsync(request);

            var temp = response.Content.ReadAsStringAsync().Result;

            List<Post> myList = JsonConvert.DeserializeObject<List<Post>>(temp);
            return myList;
        }
        public async Task<List<UserRating>> getUserRated(string userID)
        {

            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(UserApiConstants.getProfile + userID + "/rate");

            HttpResponseMessage response = await _client.SendAsync(request);

            var temp = response.Content.ReadAsStringAsync().Result;

            List<UserRating> myList = JsonConvert.DeserializeObject<List<UserRating>>(temp);
            return myList;
        }



    }
}