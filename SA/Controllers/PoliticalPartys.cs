using Newtonsoft.Json;
using SA.Data;
using SA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SA.Controllers
{
    class PoliticalPartysController
    {
        public static List<Party> GetAllParties()
        {
            var request = DatabaseService.Request("http://520351.student4a7.ao-ica.nl/api/getParties.php");
            using (var s = request.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var result = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<List<Party>>(result);
                    return data;
                }
            }
        }
    }
}
