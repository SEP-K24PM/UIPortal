using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using UI_portal.Models;
using UI_portal.Constants;
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
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(UserApiConstants.getProfile + userID);

            HttpResponseMessage response = await _client.SendAsync(request);
        
            var profile = await response.Content.ReadAsAsync<UserAccount>();
            return profile;
        }
        public async Task<List<Post>> getUserPosted()
        {

            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.NEWSFEED);

            HttpResponseMessage response = await _client.SendAsync(request);

            List<Post> newsfeed = await response.Content.ReadAsAsync<List<Post>>();
            return newsfeed;
        }


    }
}