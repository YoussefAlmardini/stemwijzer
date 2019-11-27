using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SA.Views.QuestionView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionView : ContentPage
    {
        public List<Stand> Stands;
        public int indexer = 0;
        public User User;
        public QuestionView(List<Stand> stands,User user)
        {
            InitializeComponent();
            this.Stands = stands;
            this.User = user;
            Stand.Text = Stands[0].stand;
            this.User.Session.Start();
        }

        private void SaveAnswer(object sender, EventArgs e)
        {
            Button target = (Button)sender;
            UserOpinion userOpinion = new UserOpinion();
            userOpinion.stand = Stands[indexer];


            switch (target.Text)
            {
                case "Eens":
                    userOpinion.userOpinion = "eens_pnt";
                    User.Session.AddStandPoint(userOpinion);
                    break;

                case "Helemaal eens":
                    userOpinion.userOpinion = "hlm_eens_pnt";
                    User.Session.AddStandPoint(userOpinion);
                    break;

                case "Oneens":
                    userOpinion.userOpinion = "oneens_pnt";
                    User.Session.AddStandPoint(userOpinion);
                    break;

                case "Helemaal oneens":
                    userOpinion.userOpinion = "hlm_oneens_pnt";
                    User.Session.AddStandPoint(userOpinion);
                    break;

            }
        }

        private void SaveAdvice()
        {
            //TODO Confirm Continue

        }

       
        private void ViewPreviousQuestion(object sender, EventArgs e)
        {
            this.PreviousStand();
        }

        private void ViewNextQuestion(object sender, EventArgs e)
        {
            this.NextStand();
        }

        private void Print(Label output,Stand stand)
        {
            output.Text = stand.ToString();
        }

        private void NextStand()
        {
            indexer++;
            if (indexer == Stands.Count)
            {
                indexer--;
                this.SaveAdvice();
            }
            else Print(Stand, Stands[indexer]);
        }

        private void PreviousStand()
        {

            if (indexer == 0)
            {
                Stand.Text = Stands[indexer].stand;
            }
            else indexer--; Print(Stand, Stands[indexer]);
        }
    }
}