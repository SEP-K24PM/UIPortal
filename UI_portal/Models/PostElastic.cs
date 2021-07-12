using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class PostElastic
    {
        public string id { get; set; }
        public string description { get; set; }
        public string exchange_methods { get; set; }
        public DateTime date { get; set; }
        public bool visible { get; set; }
        public string thing_name { get; set; }
        public string origin { get; set; }
        public string category_name { get; set; }
    }
}