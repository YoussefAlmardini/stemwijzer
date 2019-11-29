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
        bool IsAnswerd = false;
        Color ActiveButtonColor = Color.FromRgb(66, 105, 195);

        public QuestionView(List<Stand> stands,User user)
        {
            InitializeComponent();
            this.Stands = stands;
            this.User = user;
            Stand.Text = Stands[0].stand;
            this.User.Session.Start();
            this.ResetLayout();
        }

        private void SaveAnswer(object sender, EventArgs e)
        {
            this.ResetLayout();
            Button target = (Button)sender;
            target.BackgroundColor = ActiveButtonColor;
            UserOpinion userOpinion = new UserOpinion();
            userOpinion.stand = Stands[indexer];

            
            switch (target.Text)
            {
                case "Eens":
                    SetAnswer("eens_pnt", userOpinion);
                    break;

                case "Helemaal eens":
                    SetAnswer("hlm_eens_pnt", userOpinion);
                    break;

                case "Oneens":
                    SetAnswer("oneens_pnt", userOpinion);
                    break;

                case "Helemaal oneens":
                    SetAnswer("hlm_oneens_pnt", userOpinion);
                    break;

            }
        }

        private void SaveAdvice()
        {
            //Navigation.PushAsync(new ResultsView(User));
        }

        private void SetAnswer(string answer,UserOpinion op)
        {
            op.userOpinion = answer;

            if (User.Session.IsExist(op.stand))
            {
                User.Session.Update(op);
            }
            else
            {
                User.Session.AddStandPoint(op);
            }
            IsAnswerd = true;
        }
       
        private void ViewPreviousQuestion(object sender, EventArgs e)
        {

            volgende.Text = "Volgende";

            if (indexer != 0)
            {
                this.PreviousStand();
                this.ResetLayout();
                this.ValidateIsAnswerd();
                this.CheckAnswer();
            }
        }

        private async void ViewNextQuestion(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if(bt.Text == "Uitslag")
            {
                if (IsAnswerd)
                {
                    var confirm = await DisplayAlert("sure", "wil jij doorgaan?", "ja zeker", "cancel");
                    if (confirm)
                    {
                        this.SaveAdvice();
                    }
                }
                else
                {
                    DisplayAlert("Stelling niet beantwoord", "U heeft nog geen aantwoord gegeven op deze stelling", "Oké");
                }
               
            }
            else
            {
                if (IsAnswerd)
                {

                    this.NextStand();
                    if (indexer == Stands.Count - 1)
                    {
                        bt.Text = "Uitslag";
                    }
                    this.ResetLayout();
                    this.ValidateIsAnswerd();
                    this.CheckAnswer();
                }
                else
                {
                    DisplayAlert("Stelling niet beantwoord", "U heeft nog geen aantwoord gegeven op deze stelling", "Oké");
                }
            }

           
                
        }

        private void Print(Label output,Stand stand)
        {
            output.Text = stand.ToString();
        }

        private void NextStand()
        {
            indexer++;
            Print(Stand, Stands[indexer]);
        }

        private void PreviousStand()
        {

            if (indexer == 0)
            {
                Stand.Text = Stands[indexer].stand;
            }
            else indexer--; Print(Stand, Stands[indexer]);
        }
        private void CheckAnswer()
        {
            if (User.Session.UserOpinion.Count > 0)
            {
                if (IsAnswerd)
                {
                    string controlName = User.Session.UserOpinion[indexer].userOpinion;
                    this.FindByName<Button>(controlName).BackgroundColor = ActiveButtonColor;
                }
            }
        }
        private void ValidateIsAnswerd()
        {
            if (User.Session.IsExist(Stands[indexer])) {
                IsAnswerd = true;
            }
            else
            {
                IsAnswerd = false;
            }
        }
        private void ResetLayout()
        {
            eens_pnt.BackgroundColor = Color.White;
            hlm_eens_pnt.BackgroundColor = Color.White;
            hlm_oneens_pnt.BackgroundColor = Color.White;
            oneens_pnt.BackgroundColor = Color.White;
        }
    }
}