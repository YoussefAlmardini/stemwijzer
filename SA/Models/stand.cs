using System;
using System.Collections.Generic;
using System.Text;


namespace SA.Models
{
    public class Stand
    {

        public int ID { set; get; }
        public string stand { set; get; }

        public override string ToString()
        {
            return this.stand;
        }
    }
}
