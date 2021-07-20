using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class Post
    {
        public string id { get; set; }
        [StringLength(500)]
        public string description { get; set; }
        public DateTime created_time { get; set; }
        public bool visible { get; set; }
        public bool deletion { get; set; }
        [Required]
        [StringLength(100)]
        public string contact { get; set; }
        public string exchange_method { get; set; }
        public string status { get; set; }
        public string thing_id { get; set; }
        public string given { get; set; }
        public string giver { get; set; }

        public Thing thing { get; set; }
        public List<PostRegistration> postRegistrationList { get; set; }
    }
}