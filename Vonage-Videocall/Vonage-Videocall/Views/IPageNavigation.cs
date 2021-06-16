using System.Threading.Tasks;
using Xamarin.Forms;

namespace VonageVideocall.Views
{
    public interface IPageNavigation
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();
        Task<Page> PopAsync(bool animated);
        Task PushModalAsync(Page page);
        Task<Page> PopModalAsync();

    }
}
