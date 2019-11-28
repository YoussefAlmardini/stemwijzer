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

        public decimal points
        {
            set;
            get;
        }
        public decimal adviced_percentage { set; get; }
    }

    public class PartyAdvice
    {
        public static List<Party> GetParties(List<Standpoints> partiesStandPoints)
        {
            List<Party> parties = new List<Party>();

            for (int i = 0; i < partiesStandPoints.Count; i++)
            {
                bool doubleRecord = false;

                for (int j = 0; j < parties.Count; j++)
                {
                    if (parties[j].name == partiesStandPoints[i].name)
                    {
                        doubleRecord = true;
                        break;
                    }
                }

                if (!doubleRecord)
                {
                    Party currentParty = new Party();
                    currentParty.name = partiesStandPoints[i].name;
                    currentParty.leader = partiesStandPoints[i].leader;
                    currentParty.parlement_chairs = Convert.ToInt32(partiesStandPoints[i].parlement_chairs);
                    currentParty.senate_chairs = Convert.ToInt32(partiesStandPoints[i].senate_chairs);
                    currentParty.abbreviation = partiesStandPoints[i].abbreviation;
                    currentParty.points = 0;
                    parties.Add(currentParty);
                }

            }//End for loop

            return parties;
        }
    }
}
