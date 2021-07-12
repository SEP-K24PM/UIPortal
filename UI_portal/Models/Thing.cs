using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class Thing
    {
        private string id { get; set; }
        private String thing_name { get; set; }
        private String origin { get; set; }
        private int price { get; set; }
        private int quantity { get; set; }
        private String used_time { get; set; }
        private String image { get; set; }
        private string user_id { get; set; }
        private string category_id { get; set; }
        private UserAccount userAccount { get; set; }
        private Category category { get; set; }
        private Post post { get; set; }
}
}