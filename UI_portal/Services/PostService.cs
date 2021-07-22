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

        public async Task<List<Post>> GetNewsfeed()
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.NEWSFEED);

            HttpResponseMessage response = await _client.SendAsync(request);

            List<Post> newsfeed = new List<Post>();
            if(response.Content != null)
            {
                newsfeed = await response.Content.ReadAsAsync<List<Post>>();
            }
            return newsfeed;
        }

        public async Task<Post> GetDetails(string postId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.DETAILS + postId);

            HttpResponseMessage response = await _client.SendAsync(request);

            var post = await response.Content.ReadAsAsync<Post>();
            return post;
        }

        public async Task<Post> CreatePost(Post post)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.SAVE);

            var convertedPost = JsonConvert.SerializeObject(post);
            request.Content = new StringContent(convertedPost, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            Post savedPost = await response.Content.ReadAsAsync<Post>();
            return savedPost;
        }

        public async Task<Post> UpdatePost(Post post)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.UPDATE + post.id);

            var convertedPost = JsonConvert.SerializeObject(post);
            request.Content = new StringContent(convertedPost, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            Post updatedPost = await response.Content.ReadAsAsync<Post>();
            return updatedPost;
        }

        public async Task DeletePost(string postId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.DELETE + postId);
            await _client.SendAsync(request);
        }

        public async Task<List<PostElastic>> SearchPost(string search)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.SEARCH);

            var convertedSearch = JsonConvert.SerializeObject(search);
            request.Content = new StringContent(convertedSearch, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            List<PostElastic> result = await response.Content.ReadAsAsync<List<PostElastic>>();
            return result;
        }

        public async Task<Post> CancelPost(string postId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.CANCEL + postId);

            HttpResponseMessage response = await _client.SendAsync(request);

            Post post = new Post();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                post = await response.Content.ReadAsAsync<Post>();
            return post;
        }

        public async Task<Post> CompletePost(string postId, string userId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(PostApiConstants.COMPLETE);

            Post post = new Post
            {
                id = postId,
                given = userId
            };
            var convertedPost = JsonConvert.SerializeObject(post);
            request.Content = new StringContent(convertedPost, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.SendAsync(request);

            Post updatedPost = new Post();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                updatedPost = await response.Content.ReadAsAsync<Post>();
            return updatedPost;
        }
    }
}