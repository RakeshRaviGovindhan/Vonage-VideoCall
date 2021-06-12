using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
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
