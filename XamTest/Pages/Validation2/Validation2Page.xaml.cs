using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Validations.ViewModels;

namespace XamTest.Pages.Validation2
{
    public partial class Validation2Page : ContentPage
    {
        public Validation2Page()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }
    }
}

