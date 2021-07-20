using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Constants
{
    public static class RatingApiConstants
    {
        /// <summary>
        /// @PathVariable("userId") UUID userId
        /// POST METHOD
        /// </summary>
        public static string LIST_BY_USER = Endpoint.BACKEND_ENDPOINT + "/api/rating/list/";
        /// <summary>
        /// @RequestBody UserRating userRating
        /// POST METHOD
        /// </summary>
        public static string CREATE = Endpoint.BACKEND_ENDPOINT + "api/rating/create";
    }
}