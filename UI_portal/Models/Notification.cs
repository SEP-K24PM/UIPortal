using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class Notification
    {
        public string id { get; set; }
        public String description { get; set; }
        public String url { get; set; }
        public string user_id { get; set; }
        public UserAccount userAccount { get; set; }
    }
}