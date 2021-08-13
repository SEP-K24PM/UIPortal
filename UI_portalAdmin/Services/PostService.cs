using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UI_portalAdmin.Constants;
using UI_portalAdmin.Models;

namespace UI_portalAdmin.Services
{
    public class PostService
    {
        public PostService()
        {

        }

        HttpClient _client = new HttpClient();

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

    }
}