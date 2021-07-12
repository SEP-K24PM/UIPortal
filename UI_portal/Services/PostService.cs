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
    public class PostService
    {
        public PostService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<List<Post>> getNewsfeed()
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.NEWSFEED);

            HttpResponseMessage response = await _client.SendAsync(request);

            List<Post> newsfeed = await response.Content.ReadAsAsync<List<Post>>();
            return newsfeed;
        }

        public async Task<Post> getDetails(string postId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.DETAILS + postId);

            HttpResponseMessage response = await _client.SendAsync(request);

            var post = await response.Content.ReadAsAsync<Post>();
            return post;
        }
    }
}