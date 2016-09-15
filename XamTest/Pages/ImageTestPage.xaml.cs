using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamTest.Pages
{
    public partial class ImageTestPage : ContentPage
    {
        public ImageTestPage()
        {
            InitializeComponent();

            var u = new Uri("http://thumb1.shutterstock.com/display_pic_with_logo/3620582/363322034/stock-photo-isolated-tree-on-white-background-363322034.jpg");

            MyImage.Source = ImageSource.FromUri(u);
        }
    }
}

