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

            MaskPhoneNumber("(123) 556-7890");
            MaskPhoneNumber("08-123 45 67");
            MaskPhoneNumber("021-12 34 56");
            MaskPhoneNumber("021-123456");
            MaskPhoneNumber("021123456");
            MaskPhoneNumber("+46 21 12 34 56");
            MaskPhoneNumber("+4621123456");
            MaskPhoneNumber("12345");
            MaskPhoneNumber("12");
            MaskPhoneNumber("1");
            MaskPhoneNumber("");

            //var grid = new Grid
            //    {
            //        VerticalOptions = LayoutOptions.FillAndExpand,
            //        HorizontalOptions = LayoutOptions.FillAndExpand,
            //        RowDefinitions = 
            //            {
            //                new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) },
            //                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            //            },
            //        ColumnDefinitions = 
            //            {
            //                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
            //            }
            //        };

            //var container = new Frame
            //{
            //    Content = new SubPage1().Content,
            //    BackgroundColor = Color.Aqua,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand
            //};

            //var button1 = new Button() { Text = "SubPage1" };

            //button1.Clicked += (object sender, EventArgs e) => {
            //    container.Content = new SubPage1().Content;
            //};

            //var button2 = new Button() { Text = "SubPage2" };

            //button2.Clicked += (object sender, EventArgs e) => {
            //    container.Content = new SubPage2().Content;
            //};

            //grid.Children.Add(new StackLayout {
            //    Children = { 
            //        button1,
            //        button2
            //    },
            //    BackgroundColor = Color.Aqua,
            //    Padding = new Thickness(10),
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand
            //}, 0, 0);

            //grid.Children.Add(container, 0, 1);

            //grid.BackgroundColor = Color.Gray;
            //this.Padding = new Thickness(20);
            //Content = grid;
        }

        public static string MaskPhoneNumber(string phonenumber)
        {
            if (string.IsNullOrWhiteSpace(phonenumber))
            {
                return string.Empty;
            }

            var length = phonenumber.Length < 5 ? 1 : 4;
            var index = phonenumber.Length < 6 ? 0 : phonenumber.Length - 6;
            var masked = phonenumber.Remove(index, Math.Min(length, phonenumber.Length - index)).Insert(index, new string('*', length));

            System.Diagnostics.Debug.WriteLine($"{phonenumber} -> {masked}");

            return masked;
        }
    }
}