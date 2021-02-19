using System.Collections.ObjectModel;
using Acr.UserDialogs;
using Xamarin.Forms;
using ZeaEye.API.Models.Response;
using ZeaEye.API.Services;
using ZeaEye.Models;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class AddDeviceSuccessViewModel : BaseViewModel
    {
        BaseApiServices baseApiServices;
        string DeviceMacAddress;
        object DeviceName;
        string DeviceBandType;
        public AddDeviceSuccessViewModel(ObservableCollection<Controller> Devicelistdata, YourTypeDeviceList BandType, YourDeviceList YourDeviceListDataValue)
        {
            Title = "Add device";
            var DeviceMac = Devicelistdata[0] as Controller;
            DeviceMacAddress = DeviceMac.controllerId;
            DeviceName = YourDeviceListDataValue.MacAddress.ToString();
            DeviceBandType = BandType.serialNumber;
            DeviceIdValue = DeviceName.ToString();
            baseApiServices = new BaseApiServices();
        }

        private string _DeviceIdValue;

        public string DeviceIdValue
        {
            get { return _DeviceIdValue; }
            set { _DeviceIdValue = value; RaisePropertyChanged(); }
        }

        public Command ConnectedDeviceListCommand
        {
            get
            {
                return new Command(ConnectedDeviceListClick);
            }
        }
        private async void ConnectedDeviceListClick(object obj)
        {
            UserDialogs.Instance.ShowLoading("Please wait...");
            var result = await baseApiServices.SaveDevice(DeviceMacAddress, DeviceBandType, (string)DeviceName);

            if(result == "created")
            {
                await UserDialogs.Instance.AlertAsync("New Device added.", "Created", "Ok");
                MainView.Instance.Detail = new NavigationPage(new YourDevicelistPage());
            }
            if(result == "conflict")
            {
                await UserDialogs.Instance.AlertAsync("This bluetooth device already added.", "Conflict", "Ok");
            }
            UserDialogs.Instance.HideLoading();
        }

    }
}
