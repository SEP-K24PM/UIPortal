using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Constants
{
    public static class UserApiConstants
    {
        /// <summary>
        /// @PathVariable("userID") UUID userID
        /// POST METHOD
        /// </summary>
        public static string getProfile = Endpoint.BACKEND_ENDPOINT + "api/management/user/profile/";

        public static string getNotifications = Endpoint.BACKEND_ENDPOINT + "api/management/notification/list/";

        public static string REGISTRATION = Endpoint.BACKEND_ENDPOINT + "api/trade/user-regis/";
    }
}