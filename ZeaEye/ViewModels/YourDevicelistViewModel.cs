using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;
using ZeaEye.API.Services;
using ZeaEye.Models;
using ZeaEye.Views;
using ZeaEye.API.Models.Response;

namespace ZeaEye.ViewModels
{
    public class YourDevicelistViewModel : BaseViewModel
    {
        BaseApiServices baseApiServices;

        private ObservableCollection<Controller> _devicelistdata;
        public ObservableCollection<Controller> Devicelistdata
        {
            get { return _devicelistdata; }
            set { _devicelistdata = value; RaisePropertyChanged(); }
        }
        public YourDevicelistViewModel()
        {
            baseApiServices = new BaseApiServices();
            Title = "Your Devices";
            _ = DeviceList();
        }

        async Task DeviceList()
        {
            UserDialogs.Instance.ShowLoading("Please wait...");
            var result = await baseApiServices.GetDevices(Application.Current.Properties["PartneId"].ToString());
            var result1 = result.controllers[0];
            Devicelistdata = result.controllers;
            UserDialogs.Instance.HideLoading();
        }

        public Command AddDeviceCommond
        {
            get
            {
                return new Command(OnAddDeviceCommondClicked);
            }
        }
        private async void OnAddDeviceCommondClicked(object obj)
        {
            var data = obj as Controller;
            UserDialogs.Instance.ShowLoading("Please wait...");
            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new SelectedControllerPage(data));
            UserDialogs.Instance.HideLoading();
        }

        public Command scancontrollercommand
        {
            get
            {
                return new Command(OnscancontrollerScreenClicked);
            }
        }
        private async void OnscancontrollerScreenClicked(object obj)
        {
            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new ItemDetailPage(null));
        }
    }
}
