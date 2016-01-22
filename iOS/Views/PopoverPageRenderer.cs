using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamTest.iOS.Views;
using XamTest.Views.Popover;
using XamTest.iOS.Common;

[assembly:ExportRenderer (typeof(PopoverPage), typeof(PopoverPageRenderer))]
namespace XamTest.iOS.Views
{
    public class PopoverPageRenderer : ViewRenderer<PopoverPage, UIView>
    {
        private PopoverPage _formsView;
        private UIViewController _contentViewController;
        private UIPopoverController _popoverController;

        protected override void OnElementChanged(ElementChangedEventArgs<PopoverPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _formsView = e.NewElement;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Content" || e.PropertyName == "Renderer")
            {
                Device.BeginInvokeOnMainThread (() => ChangePage(Element?.Content));
                return;
            }

            if(e.PropertyName == "SetPopoverVisible")
            {
                if(_popoverController != null)
                {
                    _popoverController.Dismiss(false);
                    _popoverController = null;
                }

                var pageViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;

                _popoverController = new UIPopoverController(_contentViewController);

                _popoverController.PopoverBackgroundViewType = typeof(CustomPopoverBackgroundView);
                _popoverController.PopoverContentSize = new CoreGraphics.CGSize(_formsView.PopoverWidth, _formsView.PopoverHeight);

                _popoverController.PresentFromRect(new CoreGraphics.CGRect(_formsView.ShowFromPoint.X, _formsView.ShowFromPoint.Y, 1, 1), pageViewController.View, UIPopoverArrowDirection.Any, true);

                return;
            }

            if(e.PropertyName == "SetPopoverHidden")
            {
                if(_popoverController != null)
                {
                    _popoverController.Dismiss(false);
                    _popoverController = null;
                }

                return;
            }
        }

        private void ChangePage(Page page)
        {
            if (page != null)
            {
                try
                {
                    _contentViewController = page.CreateViewController();
                }
                catch (Exception ex)
                {
                    Console.WriteLine ("error creating page " + ex.Message);
                }
            }
            else
            {
                _contentViewController = null;
            }
        }
    }
}