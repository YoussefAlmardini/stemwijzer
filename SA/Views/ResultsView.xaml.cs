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
    public partial class ResultsView : ContentPage
    {
        public ResultsView()
        {
            InitializeComponent();
        }

        private void resetApplication(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            (Application.Current).MainPage = new NavigationPage(new MainPage());
        }
    }
}