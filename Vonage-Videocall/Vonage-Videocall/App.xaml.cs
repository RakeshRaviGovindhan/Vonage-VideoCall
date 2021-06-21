using System;
using VonageVideocall.Views;
using VonageVideocall.Vonage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VonageVideocall
{
    public partial class App : Application
    {

        #region Page Navigation

        public static IPageNavigation PageNavigation { get; set; }

        #endregion

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            PageNavigation = new PageNavigation();
            CrossVonage.Current.ApiKey = "47245794";
            CrossVonage.Current.UserToken = "T1==cGFydG5lcl9pZD00NzI0NTc5NCZzaWc9MzgyMGU0ZDJiNDMwNzJiNTZmMTczMWQzYzVlNjMyOGY2MGMwNDQzNzpzZXNzaW9uX2lkPTFfTVg0ME56STBOVGM1Tkg1LU1UWXlNelV5TWpFME1URTNNSDV3Y2psU09VeGphWFpUTDBkUmRuTkdlV1l3Y0RGM2JWRi1mZyZjcmVhdGVfdGltZT0xNjIzNTIyMTkxJm5vbmNlPTAuNDk2ODk1MzcwMDg0NzE2MyZyb2xlPXB1Ymxpc2hlciZleHBpcmVfdGltZT0xNjI2MTE0MTg5JmluaXRpYWxfbGF5b3V0X2NsYXNzX2xpc3Q9";
            CrossVonage.Current.SessionId = "1_MX40NzI0NTc5NH5-MTYyMzUyMjE0MTE3MH5wcjlSOUxjaXZTL0dRdnNGeWYwcDF3bVF-fg";
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
