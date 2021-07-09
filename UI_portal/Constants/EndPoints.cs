using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portal.Constants
{
    public static class EndPoints
    {
        /// <summary>
        /// require body String email
        /// </summary>
        public static string USER_ACCOUNT_SAVE = "http://localhost:8762/api/user-account/login";

        public static string ADMIN_ACCOUNT_SAVE = "http://localhost:8762/api/admin/login";
        /// <summary>
        /// require body Post post
        /// </summary>
        public static string POST_SAVE = "http://localhost:8762/api/post/save";
        /// <summary>
        /// require path variable string postId and body Post post
        /// </summary>
        public static string POST_UPDATE = "http://localhost:8762/api/post/update/";
        /// <summary>
        /// require path variable string postId
        /// </summary>
        public static string POST_DELETE = "http://localhost:8762/api/post/delete/";
        /// <summary>
        /// require body string search
        /// </summary>
        public static string POST_SEARCH = "http://localhost:8762/api/search/posts";

        /// <summary>
        /// requiremt path variable string userId
        /// </summary>
        public static string THING_LIST_BY_USER = "http://localhost:8762/api/thing/list/";
        /// <summary>
        /// require path variable string thingId
        /// </summary>
        public static string THING_DETAILS = "http://localhost:8762/api/thing/details/";
        /// <summary>
        /// require body Thing thing
        /// </summary>
        public static string THING_ADD = "http://localhost:8762/api/thing/add";
        /// <summary>
        /// require path variable string thingId and body Thing thing
        /// </summary>
        public static string THING_UPDATE = "http://localhost:8762/api/thing/update/";
        /// <summary>
        /// require path variable string thingId
        /// </summary>
        public static string THING_DELETE = "http://localhost:8762/api/thing/delete/";
    }
}