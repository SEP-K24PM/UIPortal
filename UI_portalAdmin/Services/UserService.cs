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
            var users = new List<UserAccount>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(AdminApiConstants.USER_LIST);

                HttpResponseMessage response = await _client.SendAsync(request);

                users = await response.Content.ReadAsAsync<List<UserAccount>>();
            }
            catch (Exception e) { Console.Write(e); }
            return users;
        }

        public async Task<UserHandling> BlockUser(UserHandling userHandling)
        {
            var blockedUser = new UserHandling();
            try
            {
                var convertedUserHandling = JsonConvert.SerializeObject(userHandling);
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(AdminApiConstants.USER_BLOCK);
                request.Content = new StringContent(convertedUserHandling, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.SendAsync(request);

                blockedUser = await response.Content.ReadAsAsync<UserHandling>();
            }
            catch (Exception e) { Console.Write(e); }
            return blockedUser;
        }

        public async Task<UserAccount> GetUser(string userId)
        {
            var user = new UserAccount();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(AdminApiConstants.USER_HANDLING_DETAILS + userId);

                HttpResponseMessage response = await _client.SendAsync(request);

                user = await response.Content.ReadAsAsync<UserAccount>();
            }
            catch (Exception e) { Console.Write(e); }
            return user;
        }
    }
}