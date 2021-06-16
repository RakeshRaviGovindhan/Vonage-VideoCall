using System.Threading.Tasks;
using Xamarin.Forms;

namespace VonageVideocall.Views
{
    public class PageNavigation : IPageNavigation
    {
        private INavigation Navigation { get { return Application.Current.MainPage.Navigation; } }
        public async Task PushAsync(Page page) => await Navigation.PushAsync(page);
        public async Task<Page> PopAsync() => await Navigation.PopAsync();
        public async Task<Page> PopAsync(bool animated) => await Navigation.PopAsync(animated);
        public async Task PushModalAsync(Page page) => await Navigation.PushModalAsync(page);
        public async Task<Page> PopModalAsync() => await Navigation.PopModalAsync();
    }
}
