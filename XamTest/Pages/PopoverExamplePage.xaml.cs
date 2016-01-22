using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamTest.Extensions;

namespace XamTest.Pages
{
    public partial class PopoverExamplePage : ContentPage
    {
        public PopoverExamplePage()
        {
            InitializeComponent();
        }

        private void ShowButtonClicked(object sender, EventArgs e)
        {
            var button = ((Button)sender);

            popoverPage.Show(this, new Point(button.Bounds.Location.X + (button.Bounds.Size.Width / 2), button.Bounds.Location.Y + button.Bounds.Size.Height));
        }
    }
}