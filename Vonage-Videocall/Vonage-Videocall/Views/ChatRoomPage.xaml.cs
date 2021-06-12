using System;
using System.IO;
using System.Runtime.CompilerServices;
using VonageVideocall.Vonage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VonageVideocall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatRoomPage : ContentPage
    {

        private bool _isRendererSet;

        public ChatRoomPage()
        {
            InitializeComponent();
            CrossVonage.Current.MessageReceived += OnMessageReceived;
        }

        private void OnEndCall(object sender, EventArgs e)
        {
            CrossVonage.Current.EndSession();
            CrossVonage.Current.MessageReceived -= OnMessageReceived;
            Navigation.PopAsync();
        }

        private void OnMessage(object sender, EventArgs e)
            => CrossVonage.Current.TrySendMessage($"Path.GetRandomFileName: {Path.GetRandomFileName()}");

        void OnShareScreen(object sender, EventArgs e)
        {
            CrossVonage.Current.PublisherVideoType = CrossVonage.Current.PublisherVideoType == VonagePublisherVideoType.Camera
                ? VonagePublisherVideoType.Screen
                : VonagePublisherVideoType.Camera;
        }

        private void OnMessageReceived(string message)
            => DisplayAlert("Random message received", message, "OK");
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }

        private void OnSwitchCameraClicked(object sender, EventArgs e) => CrossVonage.Current.CycleCamera();

        private void OnLocalVideoMuteClicked(object sender, EventArgs e)
        {

        }

        private void OnLocalAudioMuteClicked(object sender, EventArgs e)
        {

        }
    }
}