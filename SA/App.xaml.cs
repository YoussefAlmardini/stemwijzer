using SA.Controllers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SA.Models;

namespace SA
{
    public partial class App : Application
    {
        public static string PathName;
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
        public App(string pathName)
        {
            InitializeComponent();
            MainPage = new MainPage();
            App.PathName = pathName;
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
