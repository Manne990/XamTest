using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //RealImage.IsVisible = false;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Placeholder.Source = "https://static.pexels.com/photos/7976/pexels-photo.jpg";
            //Placeholder.Source = "testbild.jpg";

            //await Task.Delay(3000);

            //Placeholder.IsVisible = false;

            //RealImage.IsVisible = true;
            //RealImage.Source = "https://static.pexels.com/photos/7976/pexels-photo.jpg";
        }
    }
}