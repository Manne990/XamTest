using System;
using Android.Graphics;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamTest.Droid.Common;
using XamTest.Droid.Views;
using XamTest.Views.CustomFont;

[assembly: ExportRenderer(typeof(CustomFontLabel), typeof(CustomFontLabelRenderer))]
namespace XamTest.Droid.Views
{
	public class CustomFontLabelRenderer : LabelRenderer
	{
		private CustomFontLabel _formsElement;

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if(e.NewElement != null)
			{
				_formsElement = (CustomFontLabel)e.NewElement;

				UpdateFont();
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if(e.PropertyName == Xamarin.Forms.Label.FontFamilyProperty.PropertyName)
			{
				UpdateFont();
			}
		}

		private void UpdateFont()
		{
			var font = _formsElement.FontFamily;

			if (string.IsNullOrEmpty(font) == false)
			{
				var label = (TextView)this.Control;

				label.Typeface = AssetHelper.LoadTypeface(font);
			}
		}
	}
}