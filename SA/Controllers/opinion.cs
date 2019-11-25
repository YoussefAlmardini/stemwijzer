using Newtonsoft.Json;
using SA.Data;
using SA.Models;
using System.Collections.Generic;
using System.IO;

namespace SA.Controllers
{
    internal class OpinionsController
    {
        public static List<Opinion> GetOpinions()
        {
           var request = DatabaseService.Request("http://145.120.207.142/databaseConnect/getOpinions.php");
            using (var s = request.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var result = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<List<Opinion>>(result);
                    return data;
                }
            }
        }
    }
}
