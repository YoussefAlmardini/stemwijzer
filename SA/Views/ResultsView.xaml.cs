using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsView : ContentPage
    {
        User __user;
        List<Standpoints> __partiesStandPoints;
        List<Advice> adviceList;
        public ResultsView()
        {
            InitializeComponent();
        }
        public ResultsView(User user, List<Standpoints> partiesStandPoints)
        {
            InitializeComponent();
            InitializeData(user, partiesStandPoints);
        }


        private void InitializeData(User user, List<Standpoints> partiesStandPoints)
        {
            this.__user = user;
            this.__partiesStandPoints = partiesStandPoints;
            List<Party> parties = this.GetAdvice();
            this.ShowAdvice(parties);
        }

        private List<Party> GetAdvice()
        {
            adviceList = new List<Advice>();

            var userOpinion = __user.Session.UserOpinion;
            var partiesOpinion = __partiesStandPoints;
            var parties = PartyAdvice.GetParties(__partiesStandPoints);

            for (int i = 0; i < userOpinion.Count; i++)
            {
                var currentUserOpinion = userOpinion[i];
                Advice advice = new Advice();

                for (int j = 0; j < partiesOpinion.Count; j++)
                {
                    //If current stand is equal to party stand
                    if (currentUserOpinion.stand.ID == partiesOpinion[j].stand_id)
                    {
                        Standpoints currentStandPoint = partiesOpinion[j];

                        for (int x = 0; x < parties.Count; x++)
                        {
                            if (parties[x].name == currentStandPoint.name)
                            {
                                parties[x].points += advice.GetPoint(currentUserOpinion.userOpinion, currentStandPoint);
                            }
                        }
                    }
                }

            }
            for (int i = 0; i < parties.Count; i++)
            {
                parties[i].adviced_percentage = (parties[i].points * 100) / 10;
            }

           return parties;
        }

        private void ShowAdvice(List<Party> parties)
        {
            var sortedParties = parties.OrderBy(party => party.adviced_percentage).ToList();
            sortedParties.Reverse();

            //Set values best adviced party          
            Partij1_name.Text = sortedParties[0].name;
            Partij1_abbreviation.Text += sortedParties[0].abbreviation;
            Partij1_leader.Text += sortedParties[0].leader;
            Partij1_parlement_chairs.Text += sortedParties[0].parlement_chairs;
            Partij1_senatechairs.Text += sortedParties[0].senate_chairs;
            Partij1_percentage.Text += sortedParties[0].adviced_percentage + "%";
            //Set values second adviced party
            Partij2_name.Text = sortedParties[1].name;
            Partij2_abbreviation.Text += sortedParties[1].abbreviation;
            Partij2_leader.Text += sortedParties[1].leader;
            Partij2_parlement_chairs.Text += sortedParties[1].parlement_chairs;
            Partij2_senatechairs.Text += sortedParties[1].senate_chairs;
            Partij2_percentage.Text += sortedParties[1].adviced_percentage + "%";
            //Set values third adviced party
            Partij3_name.Text = sortedParties[2].name;
            Partij3_abbreviation.Text += sortedParties[2].abbreviation;
            Partij3_leader.Text += sortedParties[2].leader;
            Partij3_parlement_chairs.Text += sortedParties[2].parlement_chairs;
            Partij3_senatechairs.Text += sortedParties[2].senate_chairs;
            Partij3_percentage.Text += sortedParties[2].adviced_percentage + "%";
        }
    }
}