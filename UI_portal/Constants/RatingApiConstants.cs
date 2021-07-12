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
        public static string LIST_BY_USER = "http://localhost:8762/api/rating/list/";
        /// <summary>
        /// @RequestBody UserRating userRating
        /// POST METHOD
        /// </summary>
        public static string CREATE = "http://localhost:8762/api/rating/create";
    }
}