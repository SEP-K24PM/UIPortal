﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class User_Rating
    {
        public string id { get; set; }
        public string description { get; set; }
        public int rating { get; set; }
        public string rated_user_id { get; set; }
        public string rater_id { get; set; }
    }
}