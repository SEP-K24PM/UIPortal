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
        public static string NEWSFEED = "http://localhost:8762/api/search/newsfeed/";
        /// <summary>
        /// @RequestBody String search
        /// POST METHOD
        /// </summary>
        public static string SEARCH = "http://localhost:8762/api/search/posts";
        /// <summary>
        /// @PathVariable("id") String id
        /// POST METHOD
        /// </summary>
        public static string DETAILS = "http://localhost:8762/api/search/details/";
        /// <summary>
        /// @RequestBody Post post
        /// POST METHOD
        /// </summary>
        public static string SAVE = "http://localhost:8762/api/post/save";
        /// <summary>
        /// @PathVariable("postId") String postId, @RequestBody Post post
        /// POST METHOD
        /// </summary>
        public static string UPDATE = "http://localhost:8762/api/post/update/";
        /// <summary>
        /// @PathVariable("postId") UUID postId
        /// POST METHOD
        /// </summary>
        public static string DELETE = "http://localhost:8762/api/post/delete/";
    }
}