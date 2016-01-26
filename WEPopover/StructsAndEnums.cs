using System;
using ObjCRuntime;

namespace WEPopover
{
    [Native]
    public enum WEPopoverAnimationType : UInt64 // nuint
    {
        CrossFade = 0,
        Slide = 1
    }

    [Native]
    public enum WEPopoverTransitionType : UInt64 // nuint
    {
        Present = 0,
        Dismiss,
        Reposition
    }
}