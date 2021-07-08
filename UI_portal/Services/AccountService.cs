using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
            //Console.Write(response);
        }
        public async Task<string> getUserProfile()
        {
            string url = getUrl();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Thêm header vào HTTP Request
                    httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await httpClient.GetAsync(url);

                    // Phát sinh Exception nếu mã trạng thái trả về là lỗi 
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Tải thành công - statusCode {(int)response.StatusCode} {response.ReasonPhrase}");
                        // Đọc thông tin header trả về
                        //ShowHeaders(response.Headers);


                        Console.WriteLine("Starting read data");

                        // Đọc nội dung content trả về
                        string htmltext = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Nhận được {htmltext.Length} ký tự");
                        Console.WriteLine();
                        Console.WriteLine(response.RequestMessage);
                        return htmltext;
                    }
                    else
                    {
                        Console.WriteLine($"Lỗi - statusCode {response.StatusCode} {response.ReasonPhrase}");
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
        public string getUrl()
        {

            string req = "http://localhost:8762/account/user/";
            var emailUser = (string)HttpContext.Current.Session["userEmailLogin"];
            string url = req + emailUser;
            return url;
        }





    }
}