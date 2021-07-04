using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using UI_portal.Models;

namespace UI_portal.Controllers
{
    public class WebController : ApiController
    {
        string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/output.json");
        private static List<string> list_user = new List<string>();

         
        [HttpGet]
        public IEnumerable<string> GetNames()        
        {
            readfile();
            return list_user;
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
    }
}
