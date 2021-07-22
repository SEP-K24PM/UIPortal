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
    public class UserAccountService
    {
        public UserAccountService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<UserAccount> sendEmailData(UserAccount user)
        {
            var convertedUser = JsonConvert.SerializeObject(user);
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(UserAccountApiConstants.USER_ACCOUNT_LOGIN);
            request.Content = new StringContent(convertedUser, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                UserAccount noUser = new UserAccount();
                return noUser;
            }
            UserAccount resultUser = await response.Content.ReadAsAsync<UserAccount>();
            return resultUser;
        }
  
    }
}