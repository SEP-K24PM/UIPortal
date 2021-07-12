﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            request.RequestUri = new Uri(ApiConstants.NEWSFEED);

            HttpResponseMessage response = await _client.SendAsync(request);

            List<Post> newsfeed = await response.Content.ReadAsAsync<List<Post>>();
            return newsfeed;
        }
    }
}