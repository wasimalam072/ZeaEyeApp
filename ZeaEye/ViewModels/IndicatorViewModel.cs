using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class IndicatorViewModel : BaseViewModel
    {
        public bool controllerdata { get; set; }
        public string Condata { get; set; }
        ActivityIndicator activityIndicator = new ActivityIndicator { IsRunning = true };

        public IndicatorViewModel(bool _condata, string condata = null)
        {

            Title = "Add your first Controller";
            if (condata != null)
            {
                ErrorBind = _condata ? false : true;

                IsLoder = !ErrorBind;
            }
        }
        private bool _IsLoder = true;
        public bool ActivityBind { get { return false; } }
        public bool IsLoder
        {
            get { return _IsLoder; }
            set { _IsLoder = value; RaisePropertyChanged(); }
        }
        private bool _errorbind;

        public bool ErrorBind
        {
            get
            {
                return _errorbind;
            }
            set
            {
                _errorbind = value; RaisePropertyChanged();
            }
        }

        public Command trycommand
        {
            get
            {
                return new Command(OnItemDetailScreenClicked);
            }
        }
        private async void OnItemDetailScreenClicked(object obj)
        {
            (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.RemovePage((Application.Current.MainPage as MasterDetailPage).Detail.Navigation.NavigationStack[(Application.Current.MainPage as MasterDetailPage).Detail.Navigation.NavigationStack.Count - 2]);

            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
        }
    
    }
}
