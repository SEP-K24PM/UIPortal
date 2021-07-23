using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_portalAdmin.Constants
{
    public static class AdminApiConstants
    {
        /// <summary>
        /// NO REQUIREMENT
        /// GET METHOD
        /// </summary>
        public static string REPORT_LIST = Endpoint.BACKEND_ENDPOINT + "api/management/admin/list-report";
        /// <summary>
        /// @PathVariable("id") UUID id
        /// GET METHOD
        /// </summary>
        public static string REPORT_DETAILS = Endpoint.BACKEND_ENDPOINT + "api/management/admin/details-report/";
        /// <summary>
        /// @RequestBody PostReportDTO postReportDTO
        /// POST METHOD
        /// </summary>
        public static string REPORT_HANDLE = Endpoint.BACKEND_ENDPOINT + "api/management/admin/handle-report";
        /// <summary>
        /// GET METHOD
        /// </summary>
        public static string USER_LIST_HANDLING = Endpoint.BACKEND_ENDPOINT + "api/management/admin/user-handling/";
        /// <summary>
        /// @PathVariable("userId") String userId
        /// GET METHOD
        /// </summary>
        public static string USER_LIST = Endpoint.BACKEND_ENDPOINT + "api/management/admin/list-user";
        /// <summary>
        /// @RequestBody UserHandling userHandling
        /// POST METHOD
        /// </summary>
        public static string USER_BLOCK = Endpoint.BACKEND_ENDPOINT + "api/management/admin/block-user";
        /// <summary>
        /// @PathVariable("userId") String userId
        /// </summary>
        public static string USER_HANDLING_DETAILS = Endpoint.BACKEND_ENDPOINT + "api/management/admin/user-handling/";
    }
}