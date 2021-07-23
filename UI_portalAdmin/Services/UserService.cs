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
    public class UserService
    {
        public UserService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<List<UserAccount>> GetUsers()
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(AdminApiConstants.USER_LIST);

            HttpResponseMessage response = await _client.SendAsync(request);

            List<UserAccount> users = await response.Content.ReadAsAsync<List<UserAccount>>();
            return users;
        }

        public async Task<UserHandling> BlockUser(UserHandling userHandling)
        {
            var convertedUserHandling = JsonConvert.SerializeObject(userHandling);
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(AdminApiConstants.USER_BLOCK);
            request.Content = new StringContent(convertedUserHandling, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            UserHandling blockedUser = await response.Content.ReadAsAsync<UserHandling>();
            return blockedUser;
        }
    }
}