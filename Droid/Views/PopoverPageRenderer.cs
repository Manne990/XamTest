using System;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamTest.Droid.Views;
using XamTest.Views.Popover;
using PopOver;
using Android.App;

[assembly:ExportRenderer (typeof(PopoverPage), typeof(PopoverPageRenderer))]
namespace XamTest.Droid.Views
{
    public class PopoverPageRenderer : ViewRenderer<PopoverPage, Android.Views.View>
    {
        private PopoverPage _formsView;
        private PopoverView _popoverView;
        private ViewGroup _rootViewGroup;


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
                var contentView = Platform.CreateRenderer(Element?.Content);

                _popoverView = new PopoverView(this.Context, (Android.Views.View)contentView);

                return;
            }

            if(e.PropertyName == "SetPopoverVisible")
            {
                if(_popoverView != null)
                {
                    _popoverView.dissmissPopover(true);
                }

                var parentPage = (Page)GetParentPage(_formsView);
                var pageRenderer = Platform.GetRenderer(parentPage);

                //_popoverView.setContentSizeForViewInPopover(new Android.Graphics.Point(_formsView.PopoverWidth, _formsView.PopoverHeight));
                _popoverView.setContentSizeForViewInPopover(new Android.Graphics.Point(320, 340));

                //var activity = (Activity)this.Context;
                //var rootView = (ViewGroup)((ViewGroup)activity.FindViewById(Android.Resource.Id.Content)).GetChildAt(0); // Root Android view

                //var posX = Convert.ToInt32(_formsView.ShowFromPoint.X);
                //var posY = Convert.ToInt32(_formsView.ShowFromPoint.Y);

                //rootView är förmodligen fel...
                _popoverView.showPopoverFromRectInViewGroup((ViewGroup)pageRenderer, new Android.Graphics.Rect(424, 219, 656, 363), PopoverView.PopoverArrowDirectionAny, true);

                return;
            }

            if(e.PropertyName == "SetPopoverHidden")
            {
                if(_popoverView != null)
                {
                    _popoverView.dissmissPopover(true);
                }

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
    }
}