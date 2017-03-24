using System.Threading.Tasks;

namespace XamTest.Common.ExtendedPage
{
    public interface IPageExtendedLifecycle
    {
        void OnLoading();
        void OnBeforeAppearing();
    }
}
