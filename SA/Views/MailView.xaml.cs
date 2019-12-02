using SA.Controllers;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestSharp;

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
            Navigation.PopAsync();
        }

        private void requestMailRequest(Object sender, EventArgs e)
        {
            sendMailRequest(email_address.Text, "Partij 1", "Partij 2", "Partij 3", 62, 28, 10);
        }

        private void sendMailRequest(string receiver_email, string party1, string party2, string party3, int percentageParty1, int percentageParty2, int percentageParty3)
        {
            if (receiver_email != null)
            {
                var client = new RestClient("http://192.168.43.148/opleiding/jaar3/lvl10/Stemwijzer/index.php/");
                // var client = new RestClient("http://525889.student4a7.ao-ica.nl/index.php/");
                var request = new RestRequest("?email_address=" + receiver_email + "&party1=" + party1 + "&party2=" + party2 + "&party3=" + party3 + "&percentageParty1=" + percentageParty1.ToString() + "&percentageParty2=" + percentageParty2.ToString() + "&percentageParty3=" + percentageParty3.ToString(), Method.GET);
                IRestResponse response = client.Execute(request);
                DisplayAlert("Melding", "U heeft de e-mail aangevraagd, binnen enkele ogenblikken ontvangt u deze.", "OK");
            }
            else
            {
                DisplayAlert("Melding", "U heeft geen e-mailadres ingevoerd!", "OK");
            }
        }
    }
}