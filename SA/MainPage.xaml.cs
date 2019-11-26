using System;
using System.ComponentModel;
using Xamarin.Forms;
using SA.Models;
using SA.Controllers;

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
            Button btn = (Button)sender;
            btn.Text = OpinionsController.GetOpinions()[0].stand;
        }
    }
}
