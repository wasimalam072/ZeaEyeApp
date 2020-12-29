using System;
using System.Runtime.CompilerServices;
using Foundation;
using ZeaEye.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ZeaEye.iOS.Services.VersionIOS))]
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
            try
            {
                return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
