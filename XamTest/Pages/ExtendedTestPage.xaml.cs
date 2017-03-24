using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using XamTest.Common.ExtendedPage;

namespace XamTest.Pages
{
    public partial class ExtendedTestPage : ContentPage, IPageExtendedLifecycle
    {
        async public static Task<ExtendedTestPage> CreatePageAsync()
        {
            var page = new ExtendedTestPage();

            Task.Factory.StartNew(async () => {
                await page.ViewModel.SetValue1();
            });

            return page;
        }

        public ExtendedTestViewModel ViewModel;

        public ExtendedTestPage()
        {
            InitializeComponent();

            ViewModel = new ExtendedTestViewModel();

            this.BindingContext = ViewModel;

            Task.Factory.StartNew(async () =>
            {
                await ViewModel.SetValue1();
            });
        }

        private ExtendedTestPage(string value1)
        {
            InitializeComponent();

            ViewModel = new ExtendedTestViewModel();

            this.BindingContext = ViewModel;

            ViewModel.Value1 = value1;
        }

        public async void OnLoading()
        {
            System.Diagnostics.Debug.WriteLine("OnLoading");

            await ViewModel.SetValue2();
        }

        public async void OnBeforeAppearing()
        {
            System.Diagnostics.Debug.WriteLine("OnBeforeAppearing");

            //await _viewModel.SetValue3();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            System.Diagnostics.Debug.WriteLine("OnAppearing");

            await ViewModel.SetValue4();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            System.Diagnostics.Debug.WriteLine("OnDisappearing");
        }
    }

    public class ExtendedTestViewModel : ViewModelBase
    {
        public async Task SetValue1()
        {
            await Task.Delay(200);

            this.Value1 = "Value 1";
        }

        public async Task SetValue2()
        {
            await Task.Delay(200);

            this.Value2 = "Value 2";
        }

        public async Task SetValue3()
        {
            await Task.Delay(200);

            this.Value3 = "Value 3";
        }

        public async Task SetValue4()
        {
            await Task.Delay(200);

            this.Value4 = "Value 4";
        }

        private string _value1;
        public string Value1
        {
            get
            {
                return _value1;
            }
            set
            {
                if (value != _value1)
                {
                    _value1 = value;
                    RaisePropertyChanged(() => Value1);
                }
            }
        }

        private string _value2;
        public string Value2
        {
            get
            {
                return _value2;
            }
            set
            {
                if (value != _value2)
                {
                    _value2 = value;
                    RaisePropertyChanged(() => Value2);
                }
            }
        }

        private string _value3;
        public string Value3
        {
            get
            {
                return _value3;
            }
            set
            {
                if (value != _value3)
                {
                    _value3 = value;
                    RaisePropertyChanged(() => Value3);
                }
            }
        }

        private string _value4;
        public string Value4
        {
            get
            {
                return _value4;
            }
            set
            {
                if (value != _value4)
                {
                    _value4 = value;
                    RaisePropertyChanged(() => Value4);
                }
            }
        }
    }
}