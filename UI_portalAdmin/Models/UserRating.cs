using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI_portalAdmin.Models
{
    public class UserRating
    {
        public string id { get; set; }
        [StringLength(500)]
        public string description { get; set; }
        [Required]
        public int rating { get; set; }
        public string rated_user_id { get; set; }
        public string rater_id { get; set; }
        public string post_id { get; set; }
        public UserAccount rated_user { get; set; }
        public UserAccount rater { get; set; }
        public Post post { get; set; }
    }
}