using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Models
{
    public class Party
    {
        public int ID { set; get; }
        public string abbreviation { set; get; }
        public string name { set; get; }
        public string leader { set; get; }
        public int parlement_chairs { set; get; }
        public int senate_chairs { set; get; }


    }
}
