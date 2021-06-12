using Com.Opentok.Android;

namespace VonageVideocall.Droid.Services
{
    internal sealed class VonageSessionOptions : Session.SessionOptions
    {
        public override bool IsCamera2Capable => true;

        public override bool UseTextureViews() => true;
    }
}