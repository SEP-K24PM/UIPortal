using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Constants
{
    public static class PostApiConstants
    {
        /// <summary>
        /// no requirement
        /// GET METHOD
        /// </summary>
        public static string NEWSFEED = Endpoint.BACKEND_ENDPOINT + "api/search/newsfeed/";
        /// <summary>
        /// @RequestBody String search
        /// POST METHOD
        /// </summary>
        public static string SEARCH = Endpoint.BACKEND_ENDPOINT + "api/search/posts";
        /// <summary>
        /// @PathVariable("id") String id
        /// POST METHOD
        /// </summary>
        public static string DETAILS = Endpoint.BACKEND_ENDPOINT + "api/search/details/";
        /// <summary>
        /// @RequestBody Post post
        /// POST METHOD
        /// </summary>
        public static string SAVE = Endpoint.BACKEND_ENDPOINT + "api/post/save";
        /// <summary>
        /// @PathVariable("postId") String postId, @RequestBody Post post
        /// POST METHOD
        /// </summary>
        public static string UPDATE = Endpoint.BACKEND_ENDPOINT + "api/post/update/";
        /// <summary>
        /// @PathVariable("postId") UUID postId
        /// POST METHOD
        /// </summary>
        public static string DELETE = Endpoint.BACKEND_ENDPOINT + "api/post/delete/";
    }
}