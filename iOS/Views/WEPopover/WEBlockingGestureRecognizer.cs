using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace XamTest.iOS.Views.WEPopover
{
    public class WEBlockingGestureRecognizer : UIGestureRecognizer
    {
        private List<UIGestureRecognizer> _disabledGestureRecognizers;

        public WEBlockingGestureRecognizer() : base()
        {
            
        }

        public WEBlockingGestureRecognizer(NSObject target, ObjCRuntime.Selector action) : base(target, action)
        {
            this.CancelsTouchesInView = false;
            _disabledGestureRecognizers = new List<UIGestureRecognizer>();
        }

        ~WEBlockingGestureRecognizer()
        {
            RestoreDisabledGestureRecognizers();
        }




        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            if(this.State == UIGestureRecognizerState.Possible)
            {
                this.State = UIGestureRecognizerState.Began;
            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            this.State = UIGestureRecognizerState.Recognized;

            RestoreDisabledGestureRecognizers();
        }
            
        public override void TouchesCancelled(NSSet touches, UIEvent evt)
        {
            this.State = UIGestureRecognizerState.Cancelled;

            RestoreDisabledGestureRecognizers();
        }

        public override bool CanBePreventedByGestureRecognizer(UIGestureRecognizer preventingGestureRecognizer)
        {
            return false;
        }

        public override bool CanPreventGestureRecognizer(UIGestureRecognizer preventedGestureRecognizer)
        {
            return this.ShouldBeRequiredToFailByGestureRecognizer(preventedGestureRecognizer);
        }
            
        public override bool ShouldBeRequiredToFailByGestureRecognizer(UIGestureRecognizer otherGestureRecognizer)
        {
            var allowed = this.IsGestureRecognizerAllowed(otherGestureRecognizer);

            if(!allowed)
            {
                if(otherGestureRecognizer.Enabled)
                {
                    otherGestureRecognizer.Enabled = false;
                    _disabledGestureRecognizers.Add(otherGestureRecognizer);
                }
            }

            return !allowed;
        }

        public override bool ShouldRequireFailureOfGestureRecognizer(UIGestureRecognizer otherGestureRecognizer)
        {
            return false;
        }




        private bool IsGestureRecognizerAllowed(UIGestureRecognizer gr)
        {
            return gr.View.IsDescendantOfView(this.View);
        }

        private void RestoreDisabledGestureRecognizers()
        {
            if(_disabledGestureRecognizers == null)
            {
                return;
            }

            foreach(var gr in _disabledGestureRecognizers)
            {
                gr.Enabled = true;
            }

            _disabledGestureRecognizers = new List<UIGestureRecognizer>();
        }

        [Export("__dummyAction")]
        private void __dummyAction()
        {
            
        }
    }
}