using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portalAdmin.Models
{
    public class Notification
    {
        public string id { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public DateTime time { get; set; }
        public string user_id { get; set; }
        public UserAccount userAccount { get; set; }
    }
}