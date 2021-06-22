using System;
using VonageVideocall.Views;
using VonageVideocall.Vonage;
using Xamarin.Forms;

namespace VonageVideocall
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void JoinCall_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossVonage.Current.TryStartSession())
                {
                    return;
                }
                await Navigation.PushModalAsync(new ChatRoomPage());
            }
            catch (Exception ex)
            {

            }

        }
    }
}
