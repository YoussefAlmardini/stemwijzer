using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Models
{
    public class Advice
    {
        public int percentage { set; get; }
        public Party Party { set; get; }

        public decimal GetPoint(string userOpinion, Standpoints currentStandPoint)
        {
            switch (userOpinion)
            {
                case "hlm_eens_pnt":
                    return currentStandPoint.hlm_eens_pnt;
                case "eens_pnt":
                    return currentStandPoint.eens_pnt;
                case "oneens_pnt":
                    return currentStandPoint.oneens_pnt;
                case "hlm_oneens_pnt":
                    return currentStandPoint.hlm_oneens_pnt;
                default: return 0;
            }
        }
    }
}
