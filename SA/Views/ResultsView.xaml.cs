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
        public ResultsView()
        {
            InitializeComponent();
        }

        private void buildMail(string emailAddress)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("ertanarslan9101@gmail.com");
                mail.To.Add("525889@edu.rocmn.nl");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("ertanarslan9101@gmail.com", "KravatIleYelek)!@$");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void mailAdvice(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("ertanarslan9101@gmail.com", "KravatIleYelek)!@$");
                MailMessage msg = new MailMessage();
                msg.To.Add("525889@edu.rocmn.nl");
                msg.From = new MailAddress("ertanarslan9101@gmail.com");
                msg.Subject = "Advies";
                msg.Body = "U heeft een nieuwe advies gekregen.";
                client.Send(msg);
                Console.WriteLine("MAIL: SUCCESVOL");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}