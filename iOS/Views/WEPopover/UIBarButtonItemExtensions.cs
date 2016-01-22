using System;
using CoreGraphics;
using UIKit;

namespace XamTest.iOS.Views.WEPopover
{
    public static class UIBarButtonItemExtensions
    {
        public static CGRect WeFrameInView(this UIBarButtonItem self, UIView v)
        {
            return new CGRect(0, 0, 0, 0);
        }
    }
}