using System;
using Android.App;
using Android.Views;
using Android.Widget;
using PopOver;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamTest.Droid.Views;
using XamTest.Views.Popover;

[assembly:ExportRenderer (typeof(PopoverPage), typeof(PopoverPageRenderer))]
namespace XamTest.Droid.Views
{
    public class PopoverPageRenderer : ViewRenderer<PopoverPage, Android.Views.View>, PopoverView.PopoverViewDelegate
    {
        private PopoverPage _formsView;
        private PopoverView _popoverView;
        private int dpi;
        //private ViewGroup _rootViewGroup;

        protected override void OnElementChanged(ElementChangedEventArgs<PopoverPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                dpi = 3;

                _formsView = e.NewElement;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Content" || e.PropertyName == "Renderer")
            {
                var contentView = Platform.CreateRenderer(Element?.ContentPage);

                //var firstChild = ((ViewGroup)contentView).GetChildAt(0);

                //((ViewGroup)contentView).RemoveViewAt(0);

                //_popoverView = new PopoverView(this.Context, (Android.Views.View)contentView);


                _popoverView = new PopoverView(this.Context, (Android.Views.View)contentView);

                _popoverView.Del = this;

                this.SetNativeControl(_popoverView);

                return;
            }

            if(e.PropertyName == "SetPopoverVisible")
            {
                /*
                var parentPage = (Page)GetParentPage(_formsView);
                var pageRenderer = Platform.GetRenderer(parentPage);
                var pageViewGroup = (ViewGroup)pageRenderer;
                var firstChild = (ViewGroup)pageViewGroup.GetChildAt(0);

                var contentView = Platform.CreateRenderer(Element?.ContentPage);
                var popup = new PopupWindow((Android.Views.View)contentView);


                ((Activity)this.Context).RunOnUiThread(() => {
                    popup.ShowAtLocation(firstChild, GravityFlags.Center, 100, 100);
                });
                */

                var parentPage = (ContentPage)GetParentPage(_formsView);
                var pageRenderer = Platform.GetRenderer(parentPage);
                var pageViewGroup = (ViewGroup)pageRenderer;

                //var firstChild = (ViewGroup)pageViewGroup.GetChildAt(0);

                _popoverView.setContentSizeForViewInPopover(new Android.Graphics.Point(_formsView.PopoverWidth * dpi, _formsView.PopoverHeight * dpi));
                _popoverView.showPopoverFromRectInViewGroup(pageViewGroup, new Android.Graphics.Rect(Convert.ToInt32(_formsView.ShowFromPoint.X), 40, 1, 1), PopoverView.PopoverArrowDirectionAny, true);
                //_popoverView.showPopoverFromRectInViewGroup(firstChild, new Android.Graphics.Rect(Convert.ToInt32(_formsView.ShowFromPoint.X), Convert.ToInt32(_formsView.ShowFromPoint.Y), 1, 1), PopoverView.PopoverArrowDirectionAny, true);





                /*
                for(int i = 0; i < firstChild.ChildCount; i++)
                {
                    var child = firstChild.GetChildAt(i);
                }
                */
                /*
                if(_popoverView != null)
                {
                    _popoverView.dissmissPopover(true);
                }

                _popoverView.setContentSizeForViewInPopover(new Android.Graphics.Point(_formsView.PopoverWidth, _formsView.PopoverHeight));

                var parentPage = (Page)GetParentPage(_formsView);
                var pageRenderer = Platform.GetRenderer(parentPage);
                var pageViewGroup = (ViewGroup)pageRenderer;
                var firstChild = (ViewGroup)pageViewGroup.GetChildAt(0);

                //var activity = (Activity)this.Context;
                //var rootView = (ViewGroup)((ViewGroup)activity.FindViewById(Android.Resource.Id.Content)).GetChildAt(0); // Root Android view

                //var posX = Convert.ToInt32(_formsView.ShowFromPoint.X);
                //var posY = Convert.ToInt32(_formsView.ShowFromPoint.Y);

                //rootView är förmodligen fel...
                _popoverView.showPopoverFromRectInViewGroup(firstChild, new Android.Graphics.Rect(424, 219, 656, 363), PopoverView.PopoverArrowDirectionAny, false);
                */

                return;
            }
        }

        private Element GetParentPage(Element element)
        {
            if(element is Page)
            {
                return element;
            }

            return GetParentPage(element.Parent);
        }

        public void popoverViewWillShow (PopoverView view)
        {
            Console.WriteLine("POPOVER Will show");
        }


        public void popoverViewDidShow (PopoverView view)
        {
            Console.WriteLine("POPOVER Did show");
        }


        public void popoverViewWillDismiss (PopoverView view)
        {
            Console.WriteLine("POPOVER Will dismiss");
        }


        public void popoverViewDidDismiss (PopoverView view)
        {
            Console.WriteLine("POPOVER Did dismiss");
        }
    }
}