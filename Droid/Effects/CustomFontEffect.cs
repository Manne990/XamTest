using System;
using Android.Graphics;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamTest.Droid.Common;
using XamTest.Droid.Effects;

[assembly:ExportEffect (typeof(CustomFontEffect), "CustomFontEffect")]
namespace XamTest.Droid.Effects
{
	public class CustomFontEffect : PlatformEffect
	{
		private Xamarin.Forms.Label _formsLabel;
		private Xamarin.Forms.Entry _formsEntry;
		private Xamarin.Forms.Editor _formsEditor;

		protected override void OnAttached()
		{
			if(this.Element is Xamarin.Forms.Label)
			{
				_formsLabel = (Xamarin.Forms.Label)this.Element;

				UpdateLabelFont();
			}

			if(this.Element is Xamarin.Forms.Entry)
			{
				_formsEntry = (Xamarin.Forms.Entry)this.Element;

				UpdateEntryFont();
			}

			if(this.Element is Xamarin.Forms.Editor)
			{
				_formsEditor = (Xamarin.Forms.Editor)this.Element;

				UpdateEditorFont();
			}
		}

		protected override void OnDetached()
		{
			
		}

		protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);

			if(args.PropertyName == Xamarin.Forms.Label.FontFamilyProperty.PropertyName)
			{
				UpdateLabelFont();
			}
		}

		private void UpdateLabelFont()
		{
			if(_formsLabel == null)
			{
				return;
			}

			var font = _formsLabel.FontFamily;

			if (string.IsNullOrEmpty(font) == false)
			{
				var control = (TextView)this.Control;

				control.Typeface = AssetHelper.LoadTypeface(font);
			}
		}

		private void UpdateEntryFont()
		{
			if(_formsEntry == null)
			{
				return;
			}

			var font = _formsEntry.FontFamily;

			if (string.IsNullOrEmpty(font) == false)
			{
				var control = (EditText)this.Control;

				control.Typeface = AssetHelper.LoadTypeface(font);
			}
		}

		private void UpdateEditorFont()
		{
			if(_formsEditor == null)
			{
				return;
			}

			var font = _formsEditor.FontFamily;

			if (string.IsNullOrEmpty(font) == false)
			{
				var control = (EditText)this.Control;

				control.Typeface = AssetHelper.LoadTypeface(font);
			}
		}
	}
}