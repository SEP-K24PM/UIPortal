using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI_portalAdmin.Models
{
    public class Thing
    {
        public string id { get; set; }
        [Required]
        [StringLength(50)]
        public string thing_name { get; set; }
        [Required]
        [StringLength(50)]
        public string origin { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        [StringLength(100)]
        public string used_time { get; set; }
        public string image { get; set; }
        public string user_id { get; set; }
        public string category_id { get; set; }
        public UserAccount userAccount { get; set; }
        public Category category { get; set; }
    }
}