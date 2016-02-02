using System;
using Xamarin.Forms;

namespace XamTest.Views.HexagonButton
{
    public class HexagonButtonView : Image
    {
        public event EventHandler Clicked;

        public string Tag { get; set; }

        public void Click()
        {
            if(this.Clicked != null)
            {
                this.Clicked(this, new EventArgs());
            }
        }
    }

    //TODO: Custom Renderer for Android
}