using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using XamTest.Views.HexagonButton;
using XamTest.iOS.Views;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;
using System.Runtime.InteropServices;

[assembly:ExportRenderer (typeof(HexagonButtonView), typeof(HexagonButtonViewRenderer))]
namespace XamTest.iOS.Views
{
    public class HexagonButtonViewRenderer : ImageRenderer
    {
        private HexagonButtonView _formsView;

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                // Get the forms view
                _formsView = (HexagonButtonView)e.NewElement;

                // Enable user interaction on the image view
                this.Control.UserInteractionEnabled = true;

                // Set up a tap gesture recognizer
                UITapGestureRecognizer tapGesture = null;

                Action action = () => {
                    // Check if the touch is on a transparent part of the image
                    if (IsPixelTransparent(tapGesture.LocationOfTouch(0, this.Control), this.Control.Image) == false) {
                        // Execute the click event
                        _formsView.Click();
                    }
                };

                tapGesture = new UITapGestureRecognizer(action);

                this.Control.AddGestureRecognizer(tapGesture);
            }
        }

        private bool IsPixelTransparent(CGPoint point, UIImage image)
        {
            // Get the UIColor of the coordinate
            var pixelColor = GetPixelColor(point, image);

            // Check the alpha channel
            return pixelColor.CGColor.Alpha == 0f;
        }

        private UIColor GetPixelColor(CGPoint point, UIImage image)
        {
            var rawData = new byte[4];
            var handle = GCHandle.Alloc(rawData);
            UIColor resultColor = null;

            try
            {
                using (var colorSpace = CGColorSpace.CreateDeviceRGB())
                {
                    using (var context = new CGBitmapContext(rawData, 1, 1, 8, 4, colorSpace, CGImageAlphaInfo.PremultipliedLast))
                    {
                        context.DrawImage(new CGRect(-point.X, point.Y - image.Size.Height, image.Size.Width, image.Size.Height), image.CGImage);

                        float red   = (rawData[0]) / 255.0f;
                        float green = (rawData[1]) / 255.0f;
                        float blue  = (rawData[2]) / 255.0f;
                        float alpha = (rawData[3]) / 255.0f;

                        resultColor = UIColor.FromRGBA(red, green, blue, alpha);
                    }
                }
            }
            finally
            {
                handle.Free();
            }

            return resultColor;
        }
    }
}