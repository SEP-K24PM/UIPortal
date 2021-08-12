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
            var profile = new UserAccount();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(UserApiConstants.getProfile + userID);

                HttpResponseMessage response = await _client.SendAsync(request);

                profile = await response.Content.ReadAsAsync<UserAccount>();
            }
            catch (Exception e) { Console.Write(e); }
            return profile;
        }

        public async Task<List<Post>> getUserPosted(string userID)
        {
            var myList = new List<Post>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(UserApiConstants.getProfile + userID + "/post");

                HttpResponseMessage response = await _client.SendAsync(request);

                var temp = response.Content.ReadAsStringAsync().Result;

                myList = JsonConvert.DeserializeObject<List<Post>>(temp);
            }
            catch (Exception e) { Console.Write(e); }
            return myList;
        }

        public async Task<List<UserRating>> getUserRated(string userID)
        {
            var myList = new List<UserRating>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(UserApiConstants.getProfile + userID + "/rate");

                HttpResponseMessage response = await _client.SendAsync(request);

                var temp = response.Content.ReadAsStringAsync().Result;

                myList = JsonConvert.DeserializeObject<List<UserRating>>(temp);
            }
            catch (Exception e) { Console.Write(e); }
            return myList;
        }

        public async Task<List<PostRegistration>> getUserRegist(string userId)
        {
            var list = new List<PostRegistration>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(UserApiConstants.REGISTRATION + userId);

                HttpResponseMessage response = await _client.SendAsync(request);

                list = await response.Content.ReadAsAsync<List<PostRegistration>>();
            }
            catch (Exception e) { Console.Write(e); }
            return list;
        }
    }
}
