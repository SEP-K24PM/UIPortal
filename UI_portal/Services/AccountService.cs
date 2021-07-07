using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace UI_portal.Services
{
    public class AccountService
    {
        public AccountService()
        {

        }

        HttpClient _client = new HttpClient();

        public async void sendEmailData(String email)
        {
            var json = JsonConvert.SerializeObject(email);
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri("http://localhost:8762/account/save");
            request.Content = new StringContent(json);
            //HttpContent content
            StringContent content = new StringContent(email);
            //HttpResponseMessage response = await _client.PostAsync("http://localhost:8762/account/save", content);
            //HttpResponseMessage response = await _client.GetAsync("http://localhost:8762/account/show");
            HttpResponseMessage response = await _client.SendAsync(request);
            Console.Write(response);
        }
    }
}