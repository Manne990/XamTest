using System;
using Xamarin.Forms;

namespace XamTest.Views.Popover
{
    public class PopoverPage : ContentView
    {
        public PopoverPage()
        {
            this.IsVisible = false;
        }

        public Page Content { get; set; }
        public Page ParentPage { get; set; }
        public int PopoverWidth { get; set; }
        public int PopoverHeight { get; set; }
        public new bool IsVisible { get; private set; }
        public Point ShowFromPoint { get; private set; }

        private static readonly BindableProperty SetPopoverVisibleProperty = BindableProperty.Create("SetPopoverVisible", typeof(bool), typeof(PopoverPage), false);
        private bool SetPopoverVisible
        {
            get { return (bool)GetValue(SetPopoverVisibleProperty); }
            set { SetValue(SetPopoverVisibleProperty, value); }
        }

        private static readonly BindableProperty SetPopoverHiddenProperty = BindableProperty.Create("SetPopoverHidden", typeof(bool), typeof(PopoverPage), false);
        private bool SetPopoverHidden
        {
            get { return (bool)GetValue(SetPopoverHiddenProperty); }
            set { SetValue(SetPopoverHiddenProperty, value); }
        }

        public void Show(Page parentPage, Point point)
        {
            ParentPage = parentPage;
            ShowFromPoint = point;

            this.SetPopoverVisible = !this.SetPopoverVisible;
        }

        public void Hide()
        {
            this.SetPopoverHidden = !this.SetPopoverHidden;
        }
    }
}