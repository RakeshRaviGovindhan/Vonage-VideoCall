using System.ComponentModel;
using Xamarin.Forms;

namespace VonageVideocall.Vonage
{
    [EditorBrowsable(EditorBrowsableState.Always)]
    public sealed class VonageSubscriberView : VonageView
    {
        public static readonly BindableProperty StreamIdProperty = BindableProperty.Create(nameof(StreamId), typeof(string), typeof(VonageSubscriberView));

        public string StreamId
        {
            get => GetValue(StreamIdProperty) as string;
            set => SetValue(StreamIdProperty, value);
        }
    }
}
