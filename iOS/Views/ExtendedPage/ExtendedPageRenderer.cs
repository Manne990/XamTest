using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamTest.Common.ExtendedPage;
using XamTest.iOS.Views.ExtendedPage;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Page), typeof(ExtendedPageRenderer))]
namespace XamTest.iOS.Views.ExtendedPage
{
    public class ExtendedPageRenderer : PageRenderer
    {
        public override void ViewDidLoad()
        { 
            if (this.Element is IPageExtendedLifecycle)
            {
                ((IPageExtendedLifecycle)this.Element).OnLoading();
            }

            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            if (this.Element is IPageExtendedLifecycle)
            {
                ((IPageExtendedLifecycle)this.Element).OnBeforeAppearing();
            }

            base.ViewWillAppear(animated);
        }
    }
}