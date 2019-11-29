using System;
using System.Collections.Generic;
using System.Text;
using SA.Models;

namespace SA.Models
{
    public class Standpoints
    {
        public int stand_id { get; set; }
        public decimal hlm_eens_pnt { get; set; }
        public decimal eens_pnt { get; set; }
        public decimal oneens_pnt { get; set; }
        public decimal hlm_oneens_pnt { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string leader { get; set; }
        public string parlement_chairs { get; set; }
        public string senate_chairs { get; set; }
    }
}
