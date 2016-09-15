using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace XamTest.Pages
{
    public partial class SwitchTestPage : ContentPage
    {
        private SwitchViewModel _vm;

        public SwitchTestPage()
        {
            InitializeComponent();

            _vm = new SwitchViewModel();

            this.BindingContext = _vm;
        }

        private void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Handle_Toggled fired! SyncImages: {0}", _vm.SyncImages);
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            _vm.SyncImages = !_vm.SyncImages;
        }

        private void Handle_Tapped(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Something is tapped!");
        }
    }

    public class SwitchViewModel : ViewModelBase
    {
        private bool _syncImages;
        public bool SyncImages
        {
            get { return _syncImages; }
            set
            {
                _syncImages = value;
                System.Diagnostics.Debug.WriteLine("SyncImages set to: {0}", _syncImages);
                RaisePropertyChanged(() => SyncImages);
            }
        }
    }
}