using System.Collections.ObjectModel;
using ZeaEye.Models;

namespace ZeaEye.ViewModels
{
    public class ConnectedDevicesViewModel : BaseViewModel
    {
        public ConnectedDevicesViewModel()
        {
            Title = "Add device";
            DeviceListFunction2();
            ControllerListFunction2();
        }

        private ObservableCollection<YourControllerList> _controllerList2;

        public ObservableCollection<YourControllerList> ControllerList2
        {
            get { return _controllerList2; }
            set { _controllerList2 = value; }
        }

        public void ControllerListFunction2()
        {
            ControllerList2 = new ObservableCollection<YourControllerList>()
            {
                new YourControllerList()
                {
                    ImageController = "group.png",
                    serialNumber = "927864"
                },
                new YourControllerList()
                {
                    ImageController = "group.png",
                    serialNumber = "873568347"
                }
            };
        }

        private ObservableCollection<YourDeviceList1> _controllerDevicesListData2;

        public ObservableCollection<YourDeviceList1> ControllerDevicesListData2
        {
            get { return _controllerDevicesListData2; }
            set { _controllerDevicesListData2 = value; }
        }

        public void DeviceListFunction2()
        {
            ControllerDevicesListData2 = new ObservableCollection<YourDeviceList1>()
            {
                new YourDeviceList1()
                {
                    ImageDevices = "Watch.png",
                    serialNumber = "Lifeband"
                }
            };
        }

    }
}
