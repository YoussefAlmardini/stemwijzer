using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Net.Mail;

namespace SA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsView : ContentPage
    {
        SmtpClient client = new SmtpClient();
        string host = "smtp.gmail.com";
        int port = 587;
        bool enableSsl = true;
        string credentialUsername = "ertanarslan9101@gmail.com";
        string credentialPassword = ""; // Wachtwoord
        public ResultsView()
        {
            InitializeComponent();
            initSMTPClient(host, port, enableSsl, credentialUsername, credentialPassword);
        }

        private bool initSMTPClient(string host, int port, bool enableSsl, string credentialUsername, string credentialPassword)
        {
            try
            {
                client.Host = host;
                client.Port = port;
                client.EnableSsl = enableSsl;
                client.Credentials = new NetworkCredential(credentialUsername, credentialPassword);
                client.SendCompleted += Client_SendCompleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void mailAdvice(object sender, EventArgs e)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add("wofeyay207@xmail2.net");
                msg.Subject = "Uw stemadvies";
                msg.Body = "Geachte heer/mevrouw, Hoi :)";
                msg.From = new MailAddress("ertanarslan9101@gmail.com");
                client.SendMailAsync(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CATCH: " + ex.Message);
            }
        }

        private void Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            DisplayAlert("Melding", "De mail is verzonden", "OK");
        }
    }
}