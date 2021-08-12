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
    public class RateService
    {
        public RateService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<UserRating> Rating(UserRating rating)
        {
            var savedRating = new UserRating();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(RatingApiConstants.CREATE);

                var convertedRating = JsonConvert.SerializeObject(rating);
                request.Content = new StringContent(convertedRating, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.Content != null)
                {
                    savedRating = await response.Content.ReadAsAsync<UserRating>();
                }
            }
            catch (Exception e) { Console.Write(e); }
            return savedRating;
        }

        public async Task<List<UserRating>> getRatingsByPost(string postId)
        {
            var userRatings = new List<UserRating>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(RatingApiConstants.LIST_BY_POST + postId);

                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.Content != null)
                {
                    userRatings = await response.Content.ReadAsAsync<List<UserRating>>();
                }
            }
            catch (Exception e) { Console.Write(e); }
            return userRatings;
        }
    }
}