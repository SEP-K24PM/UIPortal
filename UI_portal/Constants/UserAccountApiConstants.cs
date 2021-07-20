using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Constants
{
    public static class UserAccountApiConstants
    {
        /// <summary>
        /// @RequestBody UserAccount userAccount
        /// </summary>
        public static string USER_ACCOUNT_LOGIN = Endpoint.BACKEND_ENDPOINT + "api/management/user/login";
    }
}