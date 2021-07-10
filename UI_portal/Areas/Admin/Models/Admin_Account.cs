using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Areas.Admin.Models
{
    public class Admin_Account
    {
        public string id { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public string role { get; set; }
    }
}