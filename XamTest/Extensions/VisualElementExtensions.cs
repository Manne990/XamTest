using System;
using Xamarin.Forms;

namespace XamTest.Extensions
{
    public static class VisualElementExtensions
    {
        public static Point GetCenterPoint(this VisualElement element)
        {
            return new Point(element.Width / 2, element.Height / 2);
        }
    }
}