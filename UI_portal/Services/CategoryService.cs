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
    public class CategoryService
    {
        public CategoryService()
        {

        }

        HttpClient _client = new HttpClient();

        public async Task<List<Category>> GetCategories()
        {
            var list = new List<Category>();
            try
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(CategoryApiConstants.LIST_CATEGORIES);

                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.Content != null)
                {
                    list = await response.Content.ReadAsAsync<List<Category>>();
                }
            }
            catch (Exception e) { Console.Write(e); }
            return list;
        }
    }
}