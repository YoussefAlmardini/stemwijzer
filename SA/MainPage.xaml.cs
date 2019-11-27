﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using SA.Models;
using SA.Controllers;
using SA.Views.QuestionView;
using System.Collections.Generic;

namespace SA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        User user = new User();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
     
            if (user.IsAdult)
            {
                List<Stand> liveStands = StandController.GetStands();
                Navigation.PushAsync(new QuestionView(liveStands,user));
            }
            else
            {
                DisplayAlert("", "U moet minimaal 16 jaar zijn", "Oké");
            }
        }

        private void OnCheck(object sender, CheckedChangedEventArgs e)
        {
            CheckBox ChkBx = (CheckBox)sender;

            if (ChkBx.IsChecked)
            {
                user.IsAdult = true;
            }
            else
            {
                user.IsAdult = false;
            }
        }
    }
}
