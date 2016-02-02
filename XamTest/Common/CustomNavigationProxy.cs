using System;
using Xamarin.Forms;

namespace XamTest.Common
{
    public class CustomNavigationProxy : INavigation
    {
        #region INavigation implementation

        public void RemovePage(Page page)
        {
            throw new NotImplementedException();
        }

        public void InsertPageBefore(Page page, Page before)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task PushAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Page> PopAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task PopToRootAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task PushModalAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Page> PopModalAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task PushAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Page> PopAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task PopToRootAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task PushModalAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<Page> PopModalAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IReadOnlyList<Page> NavigationStack
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public System.Collections.Generic.IReadOnlyList<Page> ModalStack
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}