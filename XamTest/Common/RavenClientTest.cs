using System;
using SharpRaven;

namespace XamTest.Common
{
    public static class RavenClientTest
    {
        public static void Test()
        {
            var ravenClient = new RavenClient("https://dcbb67ba67344e158d826315a2c05f55:b5e949d1ab3f47d7b17599dbbc4e6f48@app.getsentry.com/55106");

            ravenClient.CaptureMessage("Hello from Xamarin!");

            try
            {
                int i2 = 0;
                int i = 10 / i2;
            }
            catch (Exception e)
            {
                ravenClient.CaptureException(e);
            }
        }
    }
}