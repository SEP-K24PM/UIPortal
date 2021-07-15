using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Constants
{
    public static class ThingApiConstants
    {
        /// <summary>
        /// @PathVariable("userId") String userId
        /// GET METHOD
        /// </summary>
        public static string LIST_AVAILABLE = "http://localhost:8762/api/thing/list-available/";
        /// <summary>
        /// @PathVariable("userId") String userId
        /// GET METHOD
        /// </summary>
        public static string LIST_BY_USER = "http://localhost:8762/api/thing/list/";
        /// <summary>
        /// @PathVariable("thingId") String thingId
        /// GET METHOD
        /// </summary>
        public static string DETAILS = "http://localhost:8762/api/thing/details/";
        /// <summary>
        /// @RequestBody Thing thing
        /// POST METHOD
        /// </summary>
        public static string ADD = "http://localhost:8762/api/thing/add";
        /// <summary>
        /// @PathVariable String thingId, @RequestBody Thing thing
        /// POST METHOD
        /// </summary>
        public static string UPDATE = "http://localhost:8762/api/thing/";
        /// <summary>
        /// @PathVariable("thingId") String thingId
        /// POST METHOD
        /// </summary>
        public static string DELETE = "http://localhost:8762/api/thing/delete/";
    }
}