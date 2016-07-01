using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamTest.Pages.Validation
{
    public partial class ValidationPage : ContentPage
    {
        public ValidationPage()
        {
            InitializeComponent();

            this.BindingContext = new ValidationViewModel();
        }
    }
}