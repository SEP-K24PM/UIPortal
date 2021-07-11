using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class PostRegistration
    {
        public string id { get; set; }
        public string description { get; set; }
        public bool choosen { get; set; }
        public string thing_id { get; set; }
        public string user_id { get; set; }
        public string post_id { get; set; }

        public Thing thing { get; set; }
        public Post post { get; set; }
        public UserAccount user { get; set; }
    }
}