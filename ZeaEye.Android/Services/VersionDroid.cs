using System;
using Android.Content.PM;
using ZeaEye.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ZeaEye.Droid.Services.VersionDroid))]
namespace ZeaEye.Droid.Services
{
    public class VersionDroid : IAppVersion
    {
        [Obsolete]
        public int GetBuild()
        {
            var context = global::Android.App.Application.Context;
            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionCode;
        }

        public string GetVersion()
        {
            var context = global::Android.App.Application.Context;

            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionName;
        }
    }
}
