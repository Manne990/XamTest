using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace XamTest.iOS.Common
{
    public class CustomPopoverBackgroundView : UIPopoverBackgroundView
    {
        public const float CONTENT_INSET = 10.0f;
        public const float CAP_INSET = 25.0f;
        public const float ARROW_BASE = 25.0f;
        public const float ARROW_HEIGHT = 25.0f;

        private UIImageView _borderImageView;
        private UIImageView _arrowView;
        private nfloat _arrowOffset;
        private UIPopoverArrowDirection _arrowDirection;

        public CustomPopoverBackgroundView (IntPtr handle) : base (handle) {

        }

        public CustomPopoverBackgroundView () {
            
        }



        [Export ("initWithFrame:")]
        public CustomPopoverBackgroundView (CGRect frame) : base (frame) {

            _borderImageView = new UIImageView(UIImage.FromBundle("img_overlay_border.png"));//.ImageWithAlignmentRectInsets(new UIEdgeInsets(CAP_INSET,CAP_INSET,CAP_INSET,CAP_INSET)));

            _borderImageView.Layer.CornerRadius = 0;

            _arrowView = new UIImageView(UIImage.FromBundle("img_overlay_arrow.png"));

            AddSubview(_borderImageView);
            AddSubview(_arrowView);
        }


        public override nfloat ArrowOffset
        {
            get
            {
                return _arrowOffset;
            }
            set
            {
                _arrowOffset = value;
            }
        }

        public override UIPopoverArrowDirection ArrowDirection {
            get {
                return _arrowDirection;
            }
            set {
                _arrowDirection = value;
            }
        }

        [Export ("contentViewInsets")]
        public static new UIEdgeInsets GetContentViewInsets () {
            return new UIEdgeInsets(CONTENT_INSET,CONTENT_INSET,CONTENT_INSET,CONTENT_INSET);
        }

        [Export ("arrowHeight")]
        public static new float GetArrowHeight () {
            return ARROW_HEIGHT;
        }

        [Export ("arrowBase")]
        public static new float GetArrowBase () {
            return ARROW_BASE;
        }

        public override void LayoutSubviews ()
        {
            base.LayoutSubviews ();

            nfloat height = Frame.Size.Height;
            nfloat width = Frame.Size.Width;
            float left = 0.0f;
            float top = 0.0f;
            nfloat coordinate = 0.0f;
            CGAffineTransform rotation = Transform;

            switch(_arrowDirection) {
                case UIPopoverArrowDirection.Up:
                    top += ARROW_HEIGHT;
                    height -= ARROW_HEIGHT;
                    coordinate = ((Frame.Size.Width / 2) + _arrowOffset);// - (ARROW_BASE/2);
                    _arrowView.Frame = new CGRect(coordinate, 0, ARROW_BASE, ARROW_HEIGHT);
                    break;
                case UIPopoverArrowDirection.Down:
                    height -= ARROW_HEIGHT;
                    coordinate = ((Frame.Size.Width / 2) + _arrowOffset);// - (ARROW_BASE/2);
                    _arrowView.Frame = new CGRect(coordinate, height, ARROW_BASE, ARROW_HEIGHT);
                    rotation = CGAffineTransform.MakeRotation( (float)Math.PI );
                    break;
                case UIPopoverArrowDirection.Left:
                    left += ARROW_BASE;
                    width -= ARROW_BASE;
                    coordinate = ((Frame.Size.Height / 2) + ArrowOffset) - (ARROW_HEIGHT/2);
                    _arrowView.Frame = new CGRect(0,coordinate, ARROW_BASE, ARROW_HEIGHT);
                    rotation = CGAffineTransform.MakeRotation( (float)-Math.PI );
                    break;
                case UIPopoverArrowDirection.Right:
                    width -= ARROW_BASE;
                    coordinate = ((Frame.Size.Height / 2) + _arrowOffset) - (ARROW_HEIGHT/2);
                    _arrowView.Frame = new CGRect(width,coordinate, ARROW_BASE, ARROW_HEIGHT);
                    rotation = CGAffineTransform.MakeRotation( (float)Math.PI/2 );
                    break;

            }

            _borderImageView.Frame = new CGRect(left,top,width,height);
            _arrowView.Transform = rotation;
        }
    }
}