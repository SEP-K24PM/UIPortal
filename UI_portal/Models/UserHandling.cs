using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class UserHandling
    {
        public string id { get; set; }
        public string handling { get; set; }
        public string reason { get; set; }
        public string user_id { get; set; }
        public string admin_id { get; set; }
        public UserAccount userAccount { get; set; }
        public UserAccount adminAccount { get; set; }
    }
}