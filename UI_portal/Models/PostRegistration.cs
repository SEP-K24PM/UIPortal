using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class PostRegistration
    {
        public PostRegistration()
        {
        }

        public PostRegistration(string des, bool chosen, string thingId, string userID, string postID)
        {
            this.description = des;
            this.chosen = chosen = false;
            this.thing_id = thingId;
            this.user_id = userID;
            this.post_id = postID;
        }
        
        public string id { get; set; }
        [StringLength(500)]
        public string description { get; set; }
        public bool chosen { get; set; }
        public string thing_id { get; set; }
        public string user_id { get; set; }
        public string post_id { get; set; }

        public Thing thing { get; set; }
        public UserAccount userAccount { get; set; }
        public Post post { get; set; }
    }
}