using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portalAdmin.Constants
{
    public static class AccountApiConstants
    {
        /// <summary>
        /// require body String email
        /// </summary>
        public static string USER_ACCOUNT_SAVE = "http://localhost:8762/api/user-account/login";
        /// <summary>
        /// 
        /// </summary>
        public static string ADMIN_ACCOUNT_SAVE = "http://localhost:8762/api/admin/login";
    }
}