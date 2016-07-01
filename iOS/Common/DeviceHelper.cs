using System;
using System.Runtime.InteropServices;
using UIKit;

namespace XamTest.iOS.Common
{
    public static class DeviceHelper
    {
        private const string HardwareProperty = "hw.machine";

        public static readonly string RawModelString;
        public static readonly DeviceModelTypes Model;
        public static bool IsTall
        {
            get
            {
                return UIDevice.CurrentDevice.UserInterfaceIdiom
                    == UIUserInterfaceIdiom.Phone
                        && UIScreen.MainScreen.Bounds.Height
                        * UIScreen.MainScreen.Scale >= 1136;
            }
        }

        [DllImport(ObjCRuntime.Constants.SystemLibrary)]
        static internal extern int sysctlbyname([MarshalAs(UnmanagedType.LPStr)] string property, IntPtr output, IntPtr oldLen, IntPtr newp, uint newlen);

        static DeviceHelper()
        {
            var pLen = Marshal.AllocHGlobal(sizeof(int));
            sysctlbyname(HardwareProperty, IntPtr.Zero, pLen, IntPtr.Zero, 0);

            var length = Marshal.ReadInt32(pLen);

            var pStr = Marshal.AllocHGlobal(length);
            sysctlbyname(HardwareProperty, pStr, pLen, IntPtr.Zero, 0);

            var hardwareStr = Marshal.PtrToStringAnsi(pStr);

            var ret = DeviceModelTypes.Unknown;

            if (hardwareStr == "iPhone1,1")
                ret = DeviceModelTypes.iPhone;
            else if (hardwareStr == "iPhone1,2")
                ret = DeviceModelTypes.iPhone3G;
            else if (hardwareStr == "iPhone2,1")
                ret = DeviceModelTypes.iPhone3GS;
            else if (hardwareStr == "iPhone3,1")
                ret = DeviceModelTypes.iPhone4;
            else if (hardwareStr == "iPhone3,3")
                ret = DeviceModelTypes.VerizoniPhone4;
            else if (hardwareStr == "iPhone4,1")
                ret = DeviceModelTypes.iPhone4S;
            else if (hardwareStr == "iPhone 5,1" || hardwareStr == "iPhone 5,2")
                ret = DeviceModelTypes.iPhone5;
            else if (hardwareStr == "iPhone5,3" || hardwareStr == "iPhone5,4")
                ret = DeviceModelTypes.iPhone5C;
            else if (hardwareStr == "iPhone6,1" || hardwareStr == "iPhone6,2")
                ret = DeviceModelTypes.iPhone5S;
            else if (hardwareStr == "iPhone7,2")
                ret = DeviceModelTypes.iPhone6;
            else if (hardwareStr == "iPhone7,1")
                ret = DeviceModelTypes.iPhone6Plus;
            else if (hardwareStr == "iPhone8,1")
                ret = DeviceModelTypes.iPhone6S;
            else if (hardwareStr == "iPhone8,2")
                ret = DeviceModelTypes.iPhone6SPlus;
            else if (hardwareStr == "iPad1,1" || hardwareStr == "iPad1,2")
                ret = DeviceModelTypes.iPad;
            else if (hardwareStr == "iPad2,1" ||hardwareStr == "iPad2,2" || hardwareStr == "iPad2,3" || hardwareStr == "iPad2,4")
                ret = DeviceModelTypes.iPad2;
            else if (hardwareStr == "iPad3,1" || hardwareStr == "iPad3,2" || hardwareStr == "iPad3,3")
                ret = DeviceModelTypes.iPad3;
            else if (hardwareStr == "iPad2,5" || hardwareStr == "iPad2,6" || hardwareStr == "iPad2,7")
                ret = DeviceModelTypes.iPadMini;
            else if (hardwareStr == "iPad3,4" || hardwareStr == "iPad3,5" || hardwareStr == "iPad3,6")
                ret = DeviceModelTypes.iPad4;
            else if (hardwareStr == "iPad4,1" || hardwareStr == "iPad4,2")
                ret = DeviceModelTypes.iPadAir;
            else if (hardwareStr == "iPad4,4" || hardwareStr == "iPad4,5" || hardwareStr == "iPad4,6")
                ret = DeviceModelTypes.iPadMini2;
            else if (hardwareStr == "iPad4,7" || hardwareStr == "iPad4,8" || hardwareStr == "iPad4,9")
                ret = DeviceModelTypes.iPadMini3;
            else if (hardwareStr == "iPad5,1" || hardwareStr == "iPad5,2")
                ret = DeviceModelTypes.iPadMini4;
            else if (hardwareStr == "iPad5,3" || hardwareStr == "iPad5,4")
                ret = DeviceModelTypes.iPadAir2;
            else if (hardwareStr == "iPad6,3" || hardwareStr == "iPad6,4")
                ret = DeviceModelTypes.iPadPro9_7;
            else if (hardwareStr == "iPad6,7" || hardwareStr == "iPad6,8")
                ret = DeviceModelTypes.iPadPro12_9;
            else if (hardwareStr == "iPod1,1")
                ret = DeviceModelTypes.iPod1G;
            else if (hardwareStr == "iPod2,1")
                ret = DeviceModelTypes.iPod2G;
            else if (hardwareStr == "iPod3,1")
                ret = DeviceModelTypes.iPod3G;
            else if (hardwareStr == "iPod4,1")
                ret = DeviceModelTypes.iPod4G;
            else if (hardwareStr == "iPod5,1")
                ret = DeviceModelTypes.iPod5G;
            else if (hardwareStr == "AppleTV2,1")
                ret = DeviceModelTypes.AppleTv2;
            else if (hardwareStr == "AppleTV3,1" || hardwareStr == "AppleTV3,2")
                ret = DeviceModelTypes.AppleTv3;
            else if (hardwareStr == "i386" || hardwareStr == "x86_64")
            {
                if (UIDevice.CurrentDevice.Model.Contains("iPhone"))
                    ret = UIScreen.MainScreen.Bounds.Height * UIScreen.MainScreen.Scale == 960 || UIScreen.MainScreen.Bounds.Width * UIScreen.MainScreen.Scale == 960 ? DeviceModelTypes.iPhone4Simulator : DeviceModelTypes.iPhoneSimulator;
                else
                    ret = DeviceModelTypes.iPadSimulator;
            }

            RawModelString = hardwareStr;
            Model = ret;
        }

        public enum DeviceModelTypes
        {
            iPhone,
            iPhone3G,
            iPhone3GS,
            iPhone4,
            VerizoniPhone4,
            iPhone4S,
            iPhone5,
            iPhone5C,
            iPhone5S,
            iPhone6,
            iPhone6Plus,
            iPhone6S,
            iPhone6SPlus,
            iPod1G,
            iPod2G,
            iPod3G,
            iPod4G,
            iPod5G,
            iPad,
            iPad2,
            iPadMini,
            iPad3,
            iPad4,
            iPadAir,
            iPadMini2,
            iPadMini3,
            iPadMini4,
            iPadAir2,
            iPadPro9_7,
            iPadPro12_9,
            AppleTv2,
            AppleTv3,
            iPhoneSimulator,
            iPhone4Simulator,
            iPadSimulator,
            Unknown
        }
    }
}