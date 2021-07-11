using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class UserAccount
    {
        public string id { get; set; }
        public string email { get; set; }
        public bool block { get; set; }
    }
}