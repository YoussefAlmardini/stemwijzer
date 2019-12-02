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
        List<Party> top3Parties = new List<Party>();
        public MailView(List<Party> sortedParties)
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
            string partyName1 = top3Parties[0].name;
            string partyName2 = top3Parties[1].name;
            string partyName3 = top3Parties[2].name;

            string partyA1 = top3Parties[0].adviced_percentage.ToString();
            string partyA2 = top3Parties[1].adviced_percentage.ToString();
            string partyA3 = top3Parties[2].adviced_percentage.ToString();

            sendMailRequest(email_address.Text, partyName1, partyName2, partyName3, partyA1, partyA2, partyA3);
        }

        private void sendMailRequest(string receiver_email, string party1, string party2, string party3, string percentageParty1, string percentageParty2, string percentageParty3)
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