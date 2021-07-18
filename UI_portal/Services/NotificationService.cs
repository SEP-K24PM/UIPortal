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
    public class NotificationService
    {
        public NotificationService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<List<Notification>> GetNotificationsAsync(string userId)
        {
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(UserApiConstants.getNotifications + userId);

            HttpResponseMessage response = await _client.SendAsync(request);

            List<Notification> list = await response.Content.ReadAsAsync<List<Notification>>();
            return list;
        }
    }
}