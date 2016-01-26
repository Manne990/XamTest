using System;
using CoreGraphics;
using UIKit;
using WEPopover;

namespace XamTest.iOS.Common
{
    public class Popover
    {
        private WEPopoverController _popoverController;

        public Popover()
        {
            _popoverController = new WEPopoverController();

            this.Properties = DefaultPopoverProperties();

            _popoverController.Delegate = new PopoverDelegate(this);
        }

        ~Popover()
        {
            if(_popoverController != null)
            {
                _popoverController.DismissPopoverAnimated(false);
                _popoverController.ContentViewController = null;
                _popoverController.Delegate = null;
                _popoverController = null;
            }

            this.PopoverClosed = null;
        }

        public bool ShouldDismiss { get; set; }

        public UIViewController ContentViewController
        {
            get { return _popoverController.ContentViewController; }
            set { _popoverController.ContentViewController = value; }
        }

        public CGSize ContentSize 
        {
            get { return _popoverController.PopoverContentSize; }
            set { _popoverController.PopoverContentSize = value; }
        }

        public Action<WEPopoverController> PopoverClosed { get; set; }

        public WEPopoverContainerViewProperties Properties 
        { 
            get { return _popoverController.ContainerViewProperties; }
            set { _popoverController.ContainerViewProperties = value; }
        }

        public void PresentFromRect(CGRect rect, UIView view, UIPopoverArrowDirection arrowDirection, bool animated)
        {
            if(_popoverController == null)
            {
                return;
            }
                
            _popoverController.PresentPopoverFromRect(rect, view, arrowDirection, animated);
        }

        public void Dismiss(bool animated)
        {
            if(_popoverController == null)
            {
                return;
            }

            _popoverController.DismissPopoverAnimated(animated);
        }

        private WEPopoverContainerViewProperties DefaultPopoverProperties()
        {
            var imageSize = new CGSize (30.0f, 30.0f);
            var bgMargin = 6.0f;
            var contentMargin = 2.0f;
            var popoverImagePath = @"Popover/";

            return new WEPopoverContainerViewProperties 
            {
                BackgroundMargins = new UIEdgeInsets(bgMargin, bgMargin, bgMargin, bgMargin),

                LeftBgCapSize = (int)(imageSize.Width/2),
                TopBgCapSize = (int)(imageSize.Width/2),

                ContentMargins = new UIEdgeInsets(contentMargin, contentMargin, contentMargin, contentMargin),
                ArrowMargin = 1.0f,

                BgImageName = popoverImagePath + @"popoverBgSimple.png",
                UpArrowImageName = popoverImagePath + @"popoverArrowUpSimple.png",
                DownArrowImageName = popoverImagePath + @"popoverArrowDownSimple.png",
                LeftArrowImageName = popoverImagePath + @"popoverArrowLeftSimple.png",
                RightArrowImageName = popoverImagePath + @"popoverArrowRightSimple.png",
            };  
        }

        private class PopoverDelegate : WEPopoverControllerDelegate
        {
            private WeakReference<Popover> _popover;

            public PopoverDelegate(Popover popover)
            {
                _popover = new WeakReference<Popover>(popover);
            }

            public override bool PopoverControllerShouldDismissPopover(WEPopoverController popoverController)
            {
                if(_popover == null)
                {
                    return false;
                }

                Popover popover;

                if(_popover.TryGetTarget(out popover))
                {
                    return popover.ShouldDismiss;
                }

                return false;
            }

            public override void PopoverControllerDidDismissPopover(WEPopoverController popoverController)
            {
                if(_popover == null)
                {
                    return;
                }

                Popover popover;

                if(_popover.TryGetTarget(out popover))
                {
                    if(popover.PopoverClosed != null)
                    {
                        popover.PopoverClosed(popoverController);
                    }
                }

            }
        }
    }
}