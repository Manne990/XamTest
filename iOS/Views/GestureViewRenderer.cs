using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(XamTest.Views.GestureView.GestureView), typeof(XamTest.iOS.Views.GestureViewRenderer))]
namespace XamTest.iOS.Views
{
    public class GestureViewRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            this.SetNativeControl(new UIView() { UserInteractionEnabled = true });

            System.Diagnostics.Debug.WriteLine("GestureSwitch: Init");
        }

        public override void TouchesBegan(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            System.Diagnostics.Debug.WriteLine("GestureSwitch: TouchesBegan");

            this.NextResponder.TouchesBegan(touches, evt);
        }

        public override void TouchesMoved(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            System.Diagnostics.Debug.WriteLine("GestureSwitch: TouchesMoved");

            this.NextResponder.TouchesMoved(touches, evt);
        }

        public override void TouchesEnded(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            System.Diagnostics.Debug.WriteLine("GestureSwitch: TouchesEnded");

            this.NextResponder.TouchesEnded(touches, evt);
        }
    }
}