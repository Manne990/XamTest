using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace XamTest.Common
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage() : base()
        {
        }

        public CustomNavigationPage(Page root) : base(root)
        {
            NavigationPage.SetHasNavigationBar(root, false);
        }
    }
}