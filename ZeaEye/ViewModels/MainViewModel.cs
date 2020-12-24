using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ZeaEye.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        
        public MainViewModel()
        {
           
        }

        private string _UserName = Xamarin.Essentials.Preferences.Get("UserName", string.Empty);

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; RaisePropertyChanged(); }
        }
    }
}
