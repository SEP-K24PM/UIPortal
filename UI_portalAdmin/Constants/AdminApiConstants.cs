﻿using System;
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
        public static string REPORT_LIST = "http://localhost:8762/api/admin/report/list";
        /// <summary>
        /// @PathVariable("id") UUID id
        /// GET METHOD
        /// </summary>
        public static string REPORT_DETAILS = "http://localhost:8762/api/admin/report/details/";

        public static string USER_LIST = "http://localhost:8762/api/admin/list-user";

        public static string BLOCK_USER = "http://localhost:8762/api/admin/block-user";
    }
}