using System.Collections.ObjectModel;
using ZeaEye.Models;
using ZeaEye.API.Models.Response;
using Xamarin.Forms;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class SelectedControllerViewModel : BaseViewModel
    {
        private ObservableCollection<Controller> _Devicelistdata;
        public ObservableCollection<Controller> Devicelistdata
        {
            get { return _Devicelistdata; }
            set { _Devicelistdata = value; RaisePropertyChanged(); }
        }
        public SelectedControllerViewModel(object DevicelistdataController)
        {
            Title = "Add device";
            var data = (Controller)DevicelistdataController;
            Devicelistdata = new ObservableCollection<Controller>();
            Devicelistdata.Add(data);
            DeviceListFunction();
        }

        private ObservableCollection<YourTypeDeviceList> _YourTypeDeviceListData;

        public ObservableCollection<YourTypeDeviceList> YourTypeDeviceListData
        {
            get { return _YourTypeDeviceListData; }
            set { _YourTypeDeviceListData = value; }
        }

        public void DeviceListFunction()
        {
            YourTypeDeviceListData = new ObservableCollection<YourTypeDeviceList>()
            {
                new YourTypeDeviceList()
                {
                    ImageDevices = "Watch.png",
                    serialNumber = "Lifeband"
                },
                new YourTypeDeviceList()
                {
                    ImageDevices = "Watch.png",
                    serialNumber = "BMS"
                },
            };
        }

        public Command<YourTypeDeviceList> SelectDeviceCommand
        {
            get
            {
                return new Command<YourTypeDeviceList>(OnSelectDeviceCommandClicked);
            }
        }
        private async void OnSelectDeviceCommandClicked(YourTypeDeviceList obj)
        {
            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new SelectedDevicePage(Devicelistdata, obj));
        }
    }
}
