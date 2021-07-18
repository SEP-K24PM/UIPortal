using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portalAdmin.Constants
{
    public static class AccountApiConstants
    {
        /// <summary>
        /// @RequestBody AdminAccount adminAccount
        /// </summary>
        public static string ADMIN_ACCOUNT_LOGIN = Endpoint.BACKEND_ENDPOINT + "api/management/admin/login";
    }
}