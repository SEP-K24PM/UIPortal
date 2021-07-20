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
        public static string LIST_AVAILABLE = Endpoint.BACKEND_ENDPOINT + "api/thing/list-available/";
        /// <summary>
        /// @PathVariable("userId") String userId
        /// GET METHOD
        /// </summary>
        public static string LIST_BY_USER = Endpoint.BACKEND_ENDPOINT + "api/thing/list/";
        /// <summary>
        /// @PathVariable("thingId") String thingId
        /// GET METHOD
        /// </summary>
        public static string DETAILS = Endpoint.BACKEND_ENDPOINT + "api/thing/details/";
        /// <summary>
        /// @PathVariable("thingId") String thingId
        /// </summary>
        public static string POST = Endpoint.BACKEND_ENDPOINT + "api/thing/get-post/";
        /// <summary>
        /// @RequestBody Thing thing
        /// POST METHOD
        /// </summary>
        public static string ADD = Endpoint.BACKEND_ENDPOINT + "api/thing/add";
        /// <summary>
        /// @PathVariable String thingId, @RequestBody Thing thing
        /// POST METHOD
        /// </summary>
        public static string UPDATE = Endpoint.BACKEND_ENDPOINT + "api/thing/update/";
        /// <summary>
        /// @PathVariable("thingId") String thingId
        /// POST METHOD
        /// </summary>
        public static string DELETE = Endpoint.BACKEND_ENDPOINT + "api/thing/delete/";
    }
}