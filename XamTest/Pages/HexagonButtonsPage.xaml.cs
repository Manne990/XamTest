using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamTest.Views.HexagonButton;

namespace XamTest.Pages
{
    public partial class HexagonButtonsPage : ContentPage
    {
        public HexagonButtonsPage()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, EventArgs args) 
        {
            var button = (HexagonButtonView)sender;

            ResultsLabel.Text = string.Format("Tapped: {0}", button.Tag);
        }
    }
}