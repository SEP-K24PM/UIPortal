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
        public static string LIST_REGISTRATION = Endpoint.BACKEND_ENDPOINT + "api/trade/list-regis/";
        /// <summary>
        /// @RequestBody PostRegistration postRegistration
        /// POST METHOD
        /// </summary>
        public static string REGISTER = Endpoint.BACKEND_ENDPOINT + "api/trade/register-post";
        /// <summary>
        /// @PathVariable("postRegisId") UUID postRegisId
        /// POST METHOD
        /// </summary>
        public static string ACCEPT_REGISTRATION = Endpoint.BACKEND_ENDPOINT + "api/trade/accept-register/";
    }
}