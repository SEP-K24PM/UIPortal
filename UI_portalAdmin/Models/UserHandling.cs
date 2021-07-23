using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI_portalAdmin.Models
{
    public class UserHandling
    {
        public string id { get; set; }
        [Required]
        [StringLength(100)]
        public string reason { get; set; }
        public string user_id { get; set; }
        public string admin_id { get; set; }
        public DateTime time { get; set; }
        public UserAccount userAccount { get; set; }
        public AdminAccount adminAccount { get; set; }
    }
}