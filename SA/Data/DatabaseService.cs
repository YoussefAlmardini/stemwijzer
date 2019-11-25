using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;


namespace SA.Data
{
    public class DatabaseService
    {

        public static WebRequest Request(string url)
        {
            var webRequest = WebRequest.Create(url) as HttpWebRequest;

            if (webRequest == null)
            {
                return null;
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            return webRequest;
        }
    }

}
