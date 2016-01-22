using System;

using Xamarin.Forms;
using XamTest.Views.Popover;

namespace XamTest
{
    public class SubPage1 : PopoverContentPage
    {
        public SubPage1()
        {
            Content = new Frame {
                Content = new Label { Text = "SubPage1", TextColor = Color.White },
                BackgroundColor = Color.Maroon,
                Padding = new Thickness(50),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
        }
    }
}