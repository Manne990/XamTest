using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            //await Task.Delay(500);

            //await this.Navigation.PushAsync(new ExtendedTestPage("Test from prev view"));

            //var page = await ExtendedTestPage.CreatePageAsync();

            //await this.Navigation.PushAsync(page);

            await this.Navigation.PushAsync(new ExtendedTestPage());
        }
    }
}