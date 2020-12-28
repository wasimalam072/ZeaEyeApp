using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using ZeaEye.Services;

namespace ZeaEye.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IAppVersion appVersion;
        public MainViewModel()
        {
            appVersion = DependencyService.Get<IAppVersion>();
            VersionNumberDisplay = appVersion.GetVersion();
        }

        private string _UserName = Preferences.Get("UserName", string.Empty);

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; RaisePropertyChanged(); }
        }
    }
}
