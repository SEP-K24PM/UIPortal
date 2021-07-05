﻿using Microsoft.Ajax.Utilities;
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
        static private string myUrl = "http:/localhost:55875/api/web";
        private static HttpClient _httpClient = new HttpClient();
        username_email username_Email = new username_email();
        private object obj;
        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public IEnumerable<string> GetNames()        
        {
            readfile();
            //POSTData(readJSON(obj), myUrl);        
            //List<string> loi = new List<string> { "Loi post API" };
            return list_user ;
        }
        public void readfile()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();
                    strArray = str.Split(',');
                    foreach(string ele in strArray)
                    {
                        string temp = ele.ToString();
                        list_user.Add(temp);
                    }
                }
            }
            list_user.Count();
        }
        private List<string> readJSON(object obj)
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
        public async Task POSTData(List<string> list , string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(myUrl);
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("", "login")
            });
                var result = await client.PostAsync("/api/web/exists", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }


    }
}
