using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamTest.Droid.Views;
using XamTest.Views.Popover;

[assembly:ExportRenderer (typeof(PopoverContentPage), typeof(PopoverContentPageRenderer))]
namespace XamTest.Droid.Views
{
    public class PopoverContentPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
        }
    }
}