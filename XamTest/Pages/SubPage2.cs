using System;

using Xamarin.Forms;

namespace XamTest
{
    public class SubPage2 : ContentPage
    {
        public SubPage2()
        {
            Content = new Frame {
                Content = new Label { Text = "SubPage2", TextColor = Color.White },
                BackgroundColor = Color.Olive,
                Padding = new Thickness(50),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
        }
    }
}