using Xamarin.Forms;

namespace XamTest.Common.ExtendedPage
{
    public class ExtendedPage : Xamarin.Forms.Page, IExtendedPageController
    {
        protected virtual void OnLoading()
        {
            
        }

        protected virtual void OnBeforeAppearing()
        {

        }

        void IExtendedPageController.SendOnLoading()
        {
            OnLoading();

            var pageContainer = this as IPageContainer<Page>;

            if (pageContainer is IExtendedPageController)
            {
                ((IExtendedPageController)pageContainer?.CurrentPage)?.SendOnLoading();
            }
        }

        void IExtendedPageController.SendOnBeforeAppearing()
        {
            OnBeforeAppearing();

            var pageContainer = this as IPageContainer<Page>;

            if (pageContainer is IExtendedPageController)
            {
                ((IExtendedPageController)pageContainer?.CurrentPage)?.SendOnBeforeAppearing();
            }
        }
    }

    public interface IExtendedPageController
    {
        void SendOnLoading();
        void SendOnBeforeAppearing();
    }
}