using Newtonsoft.Json;
using SA.Data;
using SA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SA.Controllers
{
    class StandPointsController
    {
        public static List<Standpoints> GetStandPoints()
        {
            var request = DatabaseService.Request("http://520351.student4a7.ao-ica.nl/api/getStandpoints.php");
            using (var s = request.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var result = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<List<Standpoints>>(result);
                    return data;
                }
            }
        }
    }
}
