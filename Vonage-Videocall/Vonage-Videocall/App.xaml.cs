using System;
using VonageVideocall.Vonage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VonageVideocall
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            CrossVonage.Current.ApiKey = "47245794";
            CrossVonage.Current.UserToken = "T1==cGFydG5lcl9pZD00NzI0NTc5NCZzaWc9MDk2ODA2MzI0YTRiOWU5NmM0YTcxMjAwZTI3ZGI5NzZiMzM5NmE0ZjpzZXNzaW9uX2lkPTJfTVg0ME56STBOVGM1Tkg1LU1UWXlNelE0TmpRd056WTJOWDU1WWpSbVlYTmpRak40VEhacFNGbHVXVloxTm1kYUwxbC1mZyZjcmVhdGVfdGltZT0xNjIzNDg2NDY5Jm5vbmNlPTAuMjE3MTIwMTk2OTY3MDQzNTQmcm9sZT1wdWJsaXNoZXImZXhwaXJlX3RpbWU9MTYyNjA3ODQ2NyZpbml0aWFsX2xheW91dF9jbGFzc19saXN0PQ==";
            CrossVonage.Current.SessionId = "2_MX40NzI0NTc5NH5-MTYyMzQ4NjQwNzY2NX55YjRmYXNjQjN4THZpSFluWVZ1NmdaL1l-fg";
            CrossVonage.Current.Error += (m) => MainPage.DisplayAlert("ERROR", m, "OK");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
