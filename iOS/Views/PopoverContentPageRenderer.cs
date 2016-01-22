using System;
using System.Collections.Generic;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamTest.iOS.Views;
using XamTest.Views.Popover;

[assembly:ExportRenderer (typeof(PopoverContentPage), typeof(PopoverContentPageRenderer))]
namespace XamTest.iOS.Views
{
    public class PopoverContentPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var topView = FindTopView(this.View);

            RemoveCornerRadius(topView);
        }

        private UIView FindTopView(UIView subView)
        {
            if(subView.Superview == null)
            {
                return subView;
            }

            return FindTopView(subView.Superview);
        }

        private void RemoveCornerRadius(UIView superView)
        {
            if(superView.Subviews == null)
            {
                return;
            }

            foreach(var subView in superView.Subviews)
            {
                subView.Layer.CornerRadius = 0;

                RemoveCornerRadius(subView);
            }
        }
    }
}