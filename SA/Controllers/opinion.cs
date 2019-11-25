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
           var request = DatabaseService.Request("http://520351.student4a7.ao-ica.nl/api/getOpinions.php");
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
