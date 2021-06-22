using System;
using System.Windows.Input;
using VonageVideocall.Vonage;
using Xamarin.Forms;

namespace VonageVideocall.Views
{
    public class ChatRoomPageViewModel : BindableObject
    {

        #region  Properties

        public IPageNavigation PageNavigation => App.PageNavigation;

        private bool isLoading { get; set; }
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (value == isLoading)
                    return;

                isLoading = value;
                OnPropertyChanged();
            }
        }

        private bool isCallMuted { get; set; }
        public bool IsCallMuted
        {
            get => isCallMuted;
            set
            {
                if (value == isCallMuted)
                    return;

                isCallMuted = value;
                OnPropertyChanged();
            }
        }

        private bool isAudioMuted { get; set; }
        public bool IsAudioMuted
        {
            get => isAudioMuted;
            set
            {
                if (value == isAudioMuted)
                    return;

                isAudioMuted = value;
                OnPropertyChanged();
            }
        }

        private bool isVideoMuted { get; set; }
        public bool IsVideoMuted
        {
            get => isVideoMuted;
            set
            {
                if (value == isVideoMuted)
                    return;

                isVideoMuted = value;
                OnPropertyChanged();
            }
        }

        private string audioImg { get; set; }
        public string AudioImg
        {
            get => audioImg;
            set
            {
                if (value == audioImg)
                    return;

                audioImg = value;
                OnPropertyChanged();
            }
        }

        private string videoImg { get; set; }
        public string VideoImg
        {
            get => videoImg;
            set
            {
                if (value == videoImg)
                    return;

                videoImg = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region SwitchCamera

        public ICommand SwitchCameraTappedCommand
        {
            get;
            private set;
        }
        private void SwitchCameraTapped(object obj)
        {
            try
            {
                if (!IsLoading)
                {
                    SetAppLoading();
                    CrossVonage.Current.CycleCamera();
                    ResetAppLoading();
                }
            }
            catch (Exception ex)
            {
                ResetAppLoading();
            }
        }

        #endregion

        #region MuteVideo

        public ICommand VideoMuteTappedCommand
        {
            get;
            private set;
        }
        private void VideoMuteTapped(object obj)
        {
            try
            {
                if (!IsLoading)
                {
                    SetAppLoading();
                    if (IsVideoMuted)
                    {
                        VideoImg = "ic_cam_active_call.png";
                        IsVideoMuted = false;
                        CheckCallMuted();
                        CrossVonage.Current.UnMuteVideo();
                    }
                    else
                    {
                        VideoImg = "ic_cam_disabled_call.png";
                        IsVideoMuted = true;
                        CheckCallMuted();
                        CrossVonage.Current.MuteVideo();
                    }
                    ResetAppLoading();
                }
            }
            catch (Exception ex)
            {
                ResetAppLoading();
            }
        }

        #endregion

        #region MuteAudio

        public ICommand AudioMuteTappedCommand
        {
            get;
            private set;
        }
        private void AudioMuteTapped(object obj)
        {
            try
            {
                if (!IsLoading)
                {
                    SetAppLoading();
                    if (IsAudioMuted)
                    {
                        AudioImg = "ic_mic_active_call.png";
                        IsAudioMuted = false;
                        CheckCallMuted();
                        CrossVonage.Current.UnMuteAudio();
                    }
                    else
                    {
                        AudioImg = "ic_mic_inactive_call.png";
                        IsAudioMuted = true;
                        CheckCallMuted();
                        CrossVonage.Current.MuteAudio();
                    }
                    ResetAppLoading();
                }
            }
            catch (Exception ex)
            {
                ResetAppLoading();
            }
        }

        #endregion

        #region CheckCallMuted

        private void CheckCallMuted()
        {
            if (!IsAudioMuted && !IsVideoMuted)
            {
                IsCallMuted = false;
            }
            else
            {
                IsCallMuted = true;
            }

        }

        #endregion

        #region EndCall

        public ICommand EndCallTappedCommand
        {
            get;
            private set;
        }
        private void EndCallTapped(object obj)
        {
            try
            {
                if (!IsLoading)
                {
                    SetAppLoading();
                    CrossVonage.Current.EndSession();
                    ResetAppLoading();
                    PageNavigation.PopModalAsync();
                }
            }
            catch(Exception ex)
            {
                ResetAppLoading();
            }
        }

        #endregion

        #region Check app loading

        public void SetAppLoading() => IsLoading = true;

        public void ResetAppLoading() => IsLoading = false;

        #endregion


        public ChatRoomPageViewModel()
        {
            VideoImg = "ic_cam_active_call.png";
            AudioImg = "ic_mic_active_call.png";
            SwitchCameraTappedCommand = new Command(SwitchCameraTapped);
            VideoMuteTappedCommand = new Command(VideoMuteTapped);
            AudioMuteTappedCommand = new Command(AudioMuteTapped);
            EndCallTappedCommand = new Command(EndCallTapped);
        }
    }
}
