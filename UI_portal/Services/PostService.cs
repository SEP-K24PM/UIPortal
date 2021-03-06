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
            var newsfeed = new List<Post>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(PostApiConstants.NEWSFEED);

                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.Content != null)
                {
                    newsfeed = await response.Content.ReadAsAsync<List<Post>>();
                }
            }
            catch (Exception e) { Console.Write(e); }
            return newsfeed;
        }

        public async Task<Post> GetDetails(string postId)
        {
            var post = new Post();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(PostApiConstants.DETAILS + postId);

                HttpResponseMessage response = await _client.SendAsync(request);

                post = await response.Content.ReadAsAsync<Post>();
            }
            catch (Exception e) { Console.Write(e); }
            return post;
        }

        public async Task<Post> CreatePost(Post post)
        {
            var savedPost = new Post();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(PostApiConstants.SAVE);

                var convertedPost = JsonConvert.SerializeObject(post);
                request.Content = new StringContent(convertedPost, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.SendAsync(request);

                savedPost = await response.Content.ReadAsAsync<Post>();
            }
            catch (Exception e) { Console.Write(e); }
            return savedPost;
        }

        public async Task<Post> UpdatePost(Post post)
        {
            var updatedPost = new Post();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(PostApiConstants.UPDATE + post.id);

                var convertedPost = JsonConvert.SerializeObject(post);
                request.Content = new StringContent(convertedPost, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.SendAsync(request);

                updatedPost = await response.Content.ReadAsAsync<Post>();
            }
            catch (Exception e) { Console.Write(e); }
            return updatedPost;
        }

        public async Task DeletePost(string postId)
        {
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(PostApiConstants.DELETE + postId);
                await _client.SendAsync(request);
            }
            catch (Exception e) { Console.Write(e); }
        }

        public async Task<List<PostElastic>> SearchPost(string search)
        {
            var result = new List<PostElastic>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(PostApiConstants.SEARCH);

                var convertedSearch = JsonConvert.SerializeObject(search);
                request.Content = new StringContent(convertedSearch, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.SendAsync(request);

                result = await response.Content.ReadAsAsync<List<PostElastic>>();
            }
            catch (Exception e) { Console.Write(e); }
            return result;
        }

        public async Task<Post> CancelPost(string postId)
        {
            var post = new Post();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(PostApiConstants.CANCEL + postId);

                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    post = await response.Content.ReadAsAsync<Post>();
            }
            catch (Exception e) { Console.Write(e); }

            return post;
        }

        public async Task<Post> CompletePost(string postId, string userId)
        {
            var updatedPost = new Post();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(PostApiConstants.COMPLETE + postId + "/" + userId);

                HttpResponseMessage response = await _client.SendAsync(request);
                
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    updatedPost = await response.Content.ReadAsAsync<Post>();
            }
            catch (Exception e) { Console.Write(e); }

            return updatedPost;
        }
    }
}