using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.ViewModels
{
    public class UserRatingVM
    {
        public string Post_id { get; set; }
        public string Rater { get; set; }
        public string Rated { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}