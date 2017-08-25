using System;
using Xamarin.Forms;

namespace XamTest
{
	public partial class SliderWithLabelPage : ContentPage
	{
		public SliderWithLabelPage()
		{
			InitializeComponent();
		}

		private void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
		{
			MySlider.Value = Math.Round(MySlider.Value);
		}
	}
}
