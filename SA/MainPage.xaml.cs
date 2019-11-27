using System;
using System.ComponentModel;
using Xamarin.Forms;
using SA.Models;
using SA.Controllers;
using SA.Views.QuestionView;
using System.Collections.Generic;

namespace SA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.IsAdult = true;
            if (user.IsAdult)
            {
                List<Stand> liveStands = StandController.GetStands();
                Navigation.PushAsync(new QuestionView(liveStands,user));
            }
        }
    }
}
