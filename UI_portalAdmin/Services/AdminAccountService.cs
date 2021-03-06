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
    public class AdminAccountService
    {
        public AdminAccountService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<HttpResponseMessage> SendEmailData(AdminAccount account)
        {
            var response = new HttpResponseMessage();
            try
            {
                var convertedAdmin = JsonConvert.SerializeObject(account);
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(AccountApiConstants.ADMIN_ACCOUNT_LOGIN);
                request.Content = new StringContent(convertedAdmin, Encoding.UTF8, "application/json");

                response = await _client.SendAsync(request);
            }
            catch (Exception e) { Console.Write(e); }
            return response;
        }
    }
}