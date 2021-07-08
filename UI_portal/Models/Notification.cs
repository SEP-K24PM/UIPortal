using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class Notification
    {
        public string id { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string user_id { get; set; }
        public Account user { get; set; }
    }
}