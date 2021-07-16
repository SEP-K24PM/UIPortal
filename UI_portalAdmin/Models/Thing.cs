using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portalAdmin.Models
{
    public class Thing
    {
        public string id { get; set; }
        public String thing_name { get; set; }
        public String origin { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public String used_time { get; set; }
        public String image { get; set; }
        public string user_id { get; set; }
        public string category_id { get; set; }
        public UserAccount userAccount { get; set; }
        public Category category { get; set; }
        public Post post { get; set; }
}
}