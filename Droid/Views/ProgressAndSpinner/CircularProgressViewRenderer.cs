using System;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamTest.Droid.Views.ProgressAndSpinner;
using XamTest.Views.ProgressAndSpinner;

[assembly:ExportRenderer (typeof(CircularProgressView), typeof(CircularProgressViewRenderer))]
namespace XamTest.Droid.Views.ProgressAndSpinner
{
    public class CircularProgressViewRenderer : ImageRenderer
    {
        float _startAngle = -((float)Math.PI / 2f);
        CircularProgressView _formsView;

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _formsView = (CircularProgressView)e.NewElement;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName == "Progress")
            {
                UpdateProgressView(_formsView.Progress);
            }
        }

        private void UpdateProgressView(float progress)
        {
            var imageView = this.Control;

            /*
            if(imageView.Image == null)
            {
                return;
            }
            */

            float endAngle = (float)((Math.PI * 2f * progress) + _startAngle);

            //var maskImage = CreatePieSegment(imageView.Image.Size, endAngle);

            //MaskImageWithImage(imageView, maskImage);
        }
    }
}