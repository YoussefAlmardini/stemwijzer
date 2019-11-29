using SA.Controllers;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ResultsView()
        {
            InitializeComponent();
        }
        public ResultsView(User user)
        {
            InitializeComponent();
            this.__user = user;
            Reset.Clicked += Reset_Clicked;
            Mail.Clicked += Mail_Clicked;
        }

        private void Mail_Clicked(object sender, EventArgs e)
        {
            List<Stand> liveStands = StandController.GetStands();
            Navigation.PushAsync(new MailView());
        }


        private void Reset_Clicked(object sender, EventArgs e)
        {
            List<Stand> liveStands = StandController.GetStands();
            Navigation.PushAsync(new MainPage());
        }
    }
}