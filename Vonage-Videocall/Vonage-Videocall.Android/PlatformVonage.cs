using Android.App;
using VonageVideocall.Droid.Renderers;
using VonageVideocall.Droid.Services;
using VonageVideocall.Vonage;

namespace VonageVideocall.Droid
{
    public static class PlatformVonage
    {
        internal static Activity Activity { get; private set; }

        public static PlatformVonageService Current => CrossVonage.Current as PlatformVonageService;

        public static void Init(Activity activity)
        {
            Activity = activity;
            VonagePublisherViewRenderer.Preserve();
            VonageSubscriberViewRenderer.Preserve();
            CrossVonage.Init<PlatformVonageService>();
        }
    }
}