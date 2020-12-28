using System;
using Foundation;
using ZeaEye.Services;

namespace ZeaEye.iOS.Services
{
    public class VersionIOS : IAppVersion
    {
        public int GetBuild()
        {
            return int.Parse(NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString());
        }

        public string GetVersion()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }
    }
}
