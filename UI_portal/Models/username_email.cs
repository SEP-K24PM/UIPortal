using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Models
{
    public class username_email
    {
        private static List<string> email_username;
        public void add_username_email(string ele)
        {
            email_username.Add(ele);
        }
        public List<string> show()
        {
            return email_username;
        }

    }
}