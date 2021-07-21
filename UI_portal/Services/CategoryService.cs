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
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(CategoryApiConstants.LIST_CATEGORIES);

            HttpResponseMessage response = await _client.SendAsync(request);

            List<Category> list = await response.Content.ReadAsAsync<List<Category>>();
            return list;
        }
    }
}