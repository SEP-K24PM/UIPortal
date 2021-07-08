using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class Post
    {
        public string id { get; set; }
        public string description { get; set; }
        public DateTime created_time { get; set; }
        public bool visible { get; set; }
        public bool deletion { get; set; }
        public string contact { get; set; }
        public string exchange_method { get; set; }
        public string status { get; set; }
        public string thing_id { get; set; }

        public Thing thing { get; set; }
    }
}