using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamTest
{
	public partial class ExpandableMenuPage : ContentPage
	{
		private bool _sizeSet;
		private Rectangle _option1ContainerRect;
		private Rectangle _option2ContainerRect;

		public ExpandableMenuPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			Option1Container.IsVisible = false;
			await Option1Container.LayoutTo(new Rectangle(_option1ContainerRect.X, Option1Container.Y, _option1ContainerRect.Width, 0), 0);

			Option2Container.IsVisible = false;
			await Option2Container.LayoutTo(new Rectangle(_option2ContainerRect.X, Option2Container.Y, _option2ContainerRect.Width, 0), 0);

			MenuContainer.ForceLayout();

			System.Diagnostics.Debug.WriteLine($"OnAppearing: {Option2Container.Y}");
		}

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);

			if (width > 0 && height > 0 && _sizeSet == false)
			{
				_sizeSet = true;
				_option1ContainerRect = new Rectangle(Option1Container.X, Option1Container.Y, Option1Container.Width, Option1Container.Height);
				_option2ContainerRect = new Rectangle(Option2Container.X, Option2Container.Y, Option2Container.Width, Option2Container.Height);
			}

			System.Diagnostics.Debug.WriteLine($"OnSizeAllocated: {Option2Container.Y}");
		}

		private async void Option1Clicked(object sender, System.EventArgs e)
		{
			if (Option1Container.IsVisible)
			{
				await Option1Container.LayoutTo(new Rectangle(_option1ContainerRect.X, Option1Container.Y, _option1ContainerRect.Width, 0), 300, Easing.Linear);
				Option1Container.IsVisible = false;
			}
			else
			{
				Option1Container.IsVisible = true;
				await Option1Container.LayoutTo(_option1ContainerRect, 300, Easing.Linear);
			}
		}

		private async void Option2Clicked(object sender, System.EventArgs e)
		{
			if (Option2Container.IsVisible)
			{
				await Option2Container.LayoutTo(new Rectangle(_option2ContainerRect.X, Option2Container.Y, _option2ContainerRect.Width, 0), 300, Easing.Linear);
				Option2Container.IsVisible = false;
			}
			else
			{
				Option2Container.IsVisible = true;
				await Option2Container.LayoutTo(new Rectangle(_option2ContainerRect.X, Option2Container.Y, _option2ContainerRect.Width, _option2ContainerRect.Height), 300, Easing.Linear);
			}
		}
	}
}