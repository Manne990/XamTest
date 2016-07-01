using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamTest.Pages.Validation3
{
    public partial class Validation3Page : ContentPage
    {
        public Validation3Page()
        {
            InitializeComponent();

            this.BindingContext = new Validation3ViewModel();
        }
    }
}