using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using UI_portal.Models;

namespace UI_portal.Controllers
{
    public class WebController : ApiController
    {
        static string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/output.json");
        private static List<string> list_user = new List<string>();
        static private string ResUrl = "http://localhost:8762/account/";
        private static HttpClient _httpClient = new HttpClient();
        private static HttpClient client = new HttpClient();
        string ListToJSON = "";

        [Route("api/web/post")]
        [AcceptVerbs("POST")]
        [HttpPost]
        public async Task post()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();
                    strArray = str.Split(',');
                    foreach (string ele in strArray)
                    {
                        string temp = ele.ToString();
                        list_user.Add(temp);
                    }
                }
            }
            var arrayTemp = list_user.ToArray();
            foreach(string ele in arrayTemp)
            {
                ListToJSON += ele;
            }
            using (var httpClient = new HttpClient())
            {
                var httpMessRequest = new HttpRequestMessage();
                httpMessRequest.Method = HttpMethod.Post;
                httpMessRequest.RequestUri = new Uri(ResUrl);
                httpMessRequest.Headers.Add("User-Agent", "Mozilla/5.0");

                var data = @ListToJSON;
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                httpMessRequest.Content = content;

                var httpResponeMess = await httpClient.SendAsync(httpMessRequest);

                var html = httpResponeMess.Content.ReadAsStringAsync();

                Console.WriteLine(html);

            }

        }

        /*
        [Route("api/web")]
        [AcceptVerbs("GET")]
        [HttpGet]
        public List<string> show()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();
                    strArray = str.Split(',');
                    foreach (string ele in strArray)
                    {
                        string temp = ele.ToString();
                        list_user.Add(temp);
                    }
                }
            }
            return list_user;
        }
        public string GetNames()
        {
            show();
            // GET json from : http:/localhost:55875/api/web
            //readfile();
            //readJSON();
            //List<string> loi = new List<string> { "Loi post API" };
            //return list_user ;

            var htmltask = GetWebContent("http:/localhost:55875/api/web");
            htmltask.Wait(); // Chờ tải xong
                             // Hoặc wait htmltask; nếu chuyển Main thành async 

            var html = htmltask.Result;
            Console.WriteLine(html);
            Console.WriteLine(html != null ? html.Substring(0, 255) : "Lỗi");

            return html;
        }
        
        [Route("api/web/post")]
        [AcceptVerbs("POST")]
        [HttpPost]
        public string PostContent()
        {
            var htmltask = GetWebContent("http:/localhost:55875/api/web");
            htmltask.Wait();
            var temp = htmltask.Result;
            var result = PostWebContent(temp);
            var _final = result.Result;
            return _final;
        }
        /*
        private List<string> readJSON()
        {
            List<string> parsedData = new List<string>();

            TextReader tr = File.OpenText(path);
            JsonTextReader reader = new JsonTextReader(tr);
            JsonSerializer jseri = new JsonSerializer();

            string str;
            string[] strArray;
            str = tr.ReadLine();
            strArray = str.Split(',');
            foreach (string ele in strArray)
            {
                string temp = ele.ToString();
                parsedData.Add(temp);
            }
            return parsedData;
        }
        */
        /*
        public async Task POSTData()
        {
            var httpClient = new HttpClient();
            List<string> list = readJSON();

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(myUrl);

            // Tạo StringContent
            string jsoncontent = "";
            string[] strArray = list.ToArray();
            foreach (string ele in strArray)
            {
                string temp = ele.ToString();
                jsoncontent += temp;
            }

            var httpContent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequestMessage);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);
        }
        */
        /*
        public async Task<string> GetWebContent(string url)
        {
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
        public async Task<string> PostWebContent(string htmlTask)
        {
            var content = htmlTask;
            var stringContent = new StringContent(content);
            using (var httpClient = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55875");               
                var result = await client.PostAsync("/api/web/post", stringContent);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
                return resultContent;
            }
        }
        public async Task postJsonToUrl(string jsondata)
        {
            var data = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var url = "http://localhost:55875/api/web/";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(url, data);
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }
        }
        */
    }
}
