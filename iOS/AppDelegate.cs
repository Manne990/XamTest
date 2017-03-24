using Foundation;
using UIKit;
using Xamarin.Forms;
using XamTest.iOS.Common;

namespace XamTest.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("iOS Platform: {0}, {1}", DeviceHelper.Model, DeviceHelper.RawModelString));

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {
                System.Diagnostics.Debug.WriteLine(string.Format("{0}, {1}", e.View.ToString(), e.NativeView.ToString()));
            };

            return base.FinishedLaunching(app, options);
        }
    }
}