using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace VonageVideocall.Vonage
{
    public interface IVonageService : INotifyPropertyChanged
    {
        event Action<string> Error;

        event Action<string> MessageReceived;

        event NotifyCollectionChangedEventHandler StreamIdCollectionChanged;

        ReadOnlyObservableCollection<string> StreamIdCollection { get; }

        VonagePermission Permissions { get; set; }

        VonagePublisherVideoType PublisherVideoType { get; set; }

        VonageVideoScaleStyle PublisherVideoScaleStyle { get; set; }

        VonageVideoScaleStyle SubscriberVideoScaleStyle { get; set; }

        bool IsVideoPublishingEnabled { get; set; }

        bool IsAudioPublishingEnabled { get; set; }

        bool IsVideoSubscriptionEnabled { get; set; }

        bool IsAudioSubscriptionEnabled { get; set; }

        string ApiKey { get; set; }

        string SessionId { get; set; }

        string UserToken { get; set; }

        bool IsSessionStarted { get; set; }

        bool IsPublishingStarted { get; set; }

        bool CheckPermissions();

        bool TryStartSession();

        bool TrySendMessage(string message);

        void EndSession();

        void CycleCamera();

        void MuteAudio();

        void MuteVideo();

        void UnMuteAudio();

        void UnMuteVideo();
    }

}
