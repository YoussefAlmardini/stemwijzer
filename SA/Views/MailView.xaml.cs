using SA.Controllers;
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
    public partial class MailView : ContentPage
    {
        public MailView()
        {
            InitializeComponent();
            Back.Clicked += Back_Clicked;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            List<Stand> liveStands = StandController.GetStands();
            Navigation.PushAsync(new ResultsView());
        }
    }
}