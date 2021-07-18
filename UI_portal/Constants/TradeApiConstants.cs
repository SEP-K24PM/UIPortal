using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Constants
{
    public static class TradeApiConstants
    {
        /// <summary>
        /// @PathVariable("postID") UUID postID
        /// GET METHOD
        /// </summary>
        public static string LIST_REGISTRATION = "http://localhost:8762/api/trade/list-regis/";
        /// <summary>
        /// @RequestBody PostRegistration postRegistration
        /// POST METHOD
        /// </summary>
        public static string REGISTER = "http://localhost:8762/api/trade/register-post";
        /// <summary>
        /// @PathVariable("postRegisId") UUID postRegisId
        /// POST METHOD
        /// </summary>
        public static string ACCEPT_REGISTRATION = "http://localhost:8762/api/trade/accept-register/";
        /// <summary>
        /// @PathVariable("userID") UUID userID
        /// POST METHOD
        /// </summary>
        public static string SHOW_LIST_THING_USER = "http://localhost:8762/api/thing/list-available/";
    }
}