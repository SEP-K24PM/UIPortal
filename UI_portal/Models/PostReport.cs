using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class PostReport
    {
        public string id { get; set; }
        [Required]
        public string description { get; set; }
        public string reason_by_admin { get; set; }
        public string handling { get; set; }
        public string post_id { get; set; }
        public string reporter_id { get; set; }
        public string admin_id { get; set; }

        public Post post { get; set; }
        public UserAccount reporter { get; set; }
        public AdminAccount admin { get; set; }

    }
}