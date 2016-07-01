using System;
using System.Linq;
using Android.Graphics;
using Xamarin.Forms;

namespace XamTest.Droid.Common
{
	public static class AssetHelper
	{
		public static bool AssetExists(string path, string assetName)
		{
			var assets = Forms.Context.Assets.List(path);

			return assets.Contains(assetName);
		}

		public static Typeface LoadTypeface(string font)
		{
			if(!font.Contains(".ttf"))
			{
				font += ".ttf";
			}

			if(AssetExists("Fonts", font))
			{
				return Typeface.CreateFromAsset(Forms.Context.Assets, "Fonts/" + font);
			}

			return null;
		}
	}
}