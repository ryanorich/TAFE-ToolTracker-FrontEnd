using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace TT_FrontEnd
{
    public class WebClient
    {
        // static interface to the Back-End Web-API
        public static HttpClient ApiClient = new HttpClient();

        /// <summary>
        /// Constructor grabs address for the back-end Web API
        /// </summary>
        static WebClient()
        {
            // End Point - URL of the back end
            ApiClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUrl"]);

        }
    
    }
}