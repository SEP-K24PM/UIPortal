using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class Thing
    {
        public string id { get; set; }
        public string thing_name { get; set; }
        public string origin { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string used_time { get; set; }
        public string image { get; set; }
        public string user_id { get; set; }
        public string category_id { get; set; }
        public UserAccount userAccount { get; set; }
        public Category category { get; set; }
        public Post post { get; set; }
}
}