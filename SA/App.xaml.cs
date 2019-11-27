using SA.Controllers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SA.Models;
using SA.Views;

namespace SA
{
    public partial class App : Application
    {
        public static string PathName;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ResultsView());
        }
        public App(string pathName)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ResultsView());
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
