using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class Post_Report
    {
        public string id { get; set; }
        public string description { get; set; }
        public string reason_by_admin { get; set; }
        public string handling { get; set; }
        public string post_id { get; set; }
        public string reporter_id { get; set; }
        public string admin_id { get; set; }

        public Post post { get; set; }
        
    }
}