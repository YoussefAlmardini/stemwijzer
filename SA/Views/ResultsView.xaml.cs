﻿using SA.Models;
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
        User __user;
        public ResultsView()
        {
            InitializeComponent();
        }
        public ResultsView(User user)
        {
            InitializeComponent();
            this.__user = user;
        }
    }
}