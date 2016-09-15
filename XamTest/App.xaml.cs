using Xamarin.Forms;

namespace XamTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Pages.SwitchTestPage();
        }
    }
}