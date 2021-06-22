using Android.Content;
using Android.Runtime;
using System.ComponentModel;
using System.Linq;
using VonageVideocall.Droid.Renderers;
using VonageVideocall.Vonage;
using Xamarin.Forms;
using AndroidRuntimeJniHandleOwnership = Android.Runtime.JniHandleOwnership;
using AView = Android.Views.View;
using SystemIntPtr = System.IntPtr;

[assembly: ExportRenderer(typeof(VonageSubscriberView), typeof(VonageSubscriberViewRenderer))]
namespace VonageVideocall.Droid.Renderers
{
    [Preserve(AllMembers = true)]
    public class VonageSubscriberViewRenderer : VonageViewRenderer
    {
        public VonageSubscriberViewRenderer(Context context) : base(context)
        {
        }

#pragma warning disable
        public VonageSubscriberViewRenderer(SystemIntPtr p0, AndroidRuntimeJniHandleOwnership p1) : this(PlatformVonage.Activity)
        {
        }
#pragma warning restore

        public static void Preserve() { }

        protected VonageSubscriberView VonageSubscriberView => VonageView as VonageSubscriberView;

        protected override AView GetNativeView()
        {
            var streamId = VonageSubscriberView?.StreamId;
            var subscribers = PlatformVonage.Current.Subscribers;
            return (streamId != null
                ? subscribers.FirstOrDefault(x => x.Stream?.StreamId == streamId)
                : subscribers.FirstOrDefault())?.View;
        }

        protected override void SubscribeResetControl() => PlatformVonage.Current.SubscriberUpdated += ResetControl;

        protected override void UnsubscribeResetControl() => PlatformVonage.Current.SubscriberUpdated -= ResetControl;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName)
            {
                case nameof(VonageSubscriberView.StreamId):
                    ResetControl();
                    break;
            }
        }
    }
}