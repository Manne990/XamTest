using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var grid = new Grid
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    RowDefinitions = 
                        {
                            new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) },
                            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                        },
                    ColumnDefinitions = 
                        {
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        }
                    };

            var container = new Frame
            {
                Content = new SubPage1().Content,
                BackgroundColor = Color.Aqua,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var button1 = new Button() { Text = "SubPage1" };

            button1.Clicked += (object sender, EventArgs e) => {
                container.Content = new SubPage1().Content;
            };

            var button2 = new Button() { Text = "SubPage2" };

            button2.Clicked += (object sender, EventArgs e) => {
                container.Content = new SubPage2().Content;
            };

            grid.Children.Add(new StackLayout {
                Children = { 
                    button1,
                    button2
                },
                BackgroundColor = Color.Aqua,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            }, 0, 0);

            grid.Children.Add(container, 0, 1);

            grid.BackgroundColor = Color.Gray;
            this.Padding = new Thickness(20);
            Content = grid;
        }
    }
}