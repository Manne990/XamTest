using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamTest.Pages
{
    public partial class NavPage1 : ContentPage
    {
        public NavPage1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ButtonClicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new NavPage2());
        }
    }
}

