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
            CrossVonage.Current.UserToken = "T1==cGFydG5lcl9pZD00NzI0NTc5NCZzaWc9NDhhODM5NDFmZDlkMDY5MTE0YTFjNzk0NmY1OTlmOWVhYTEzZWIxNjpzZXNzaW9uX2lkPTJfTVg0ME56STBOVGM1Tkg1LU1UWXlORE0yTnpjM01qRXlOSDVMYmxaNmJFSkthMk5VVnpCelJ6RXpXbVpoVjNONlVXbC1mZyZjcmVhdGVfdGltZT0xNjI0MzY3ODU2Jm5vbmNlPTAuMzUwOTU5OTMwNzQ2Nzc4NTYmcm9sZT1wdWJsaXNoZXImZXhwaXJlX3RpbWU9MTYyNjk1OTg1NSZpbml0aWFsX2xheW91dF9jbGFzc19saXN0PQ==";
            CrossVonage.Current.SessionId = "2_MX40NzI0NTc5NH5-MTYyNDM2Nzc3MjEyNH5LblZ6bEJKa2NUVzBzRzEzWmZhV3N6UWl-fg";
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
