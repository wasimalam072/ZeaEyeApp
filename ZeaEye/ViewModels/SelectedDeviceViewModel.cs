using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ZeaEye.Models;
using Xamarin.Essentials;
using Plugin.BLE;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeaEye.API.Models.Response;
using System.ComponentModel;
using ZeaEye.Views;
using Plugin.Permissions;

namespace ZeaEye.ViewModels
{
    public class SelectedDeviceViewModel : BaseViewModel
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        ActivityIndicator activityIndicator = new ActivityIndicator { IsRunning = false };

        private ObservableCollection<Controller> _ControllerData;
        public ObservableCollection<Controller> ControllerData
        {
            get { return _ControllerData; }
            set { _ControllerData = value; RaisePropertyChanged(); }
        }

        public SelectedDeviceViewModel(object Devicelistdata, YourTypeDeviceList YourTypeDeviceListData)
        {
            adapter = CrossBluetoothLE.Current.Adapter;
            _ = bluetoothData();
            Title = "Add device";
            ControllerData = (ObservableCollection<Controller>)Devicelistdata;

            ControllerDevicesListData1 = new ObservableCollection<YourTypeDeviceList>();
            ControllerDevicesListData1.Add(YourTypeDeviceListData);

            ControllerDevicesListData12 = new ObservableCollection<YourDeviceList>();

        }

        private ObservableCollection<YourTypeDeviceList> _controllerDevicesListData1;

        public ObservableCollection<YourTypeDeviceList> ControllerDevicesListData1
        {
            get { return _controllerDevicesListData1; }
            set { _controllerDevicesListData1 = value; }
        }


        private ObservableCollection<YourControllerList> _controllerList1;

        public ObservableCollection<YourControllerList> ControllerList1
        {
            get { return _controllerList1; }
            set { _controllerList1 = value; }
        }


        private ObservableCollection<YourDeviceList> _controllerDevicesListData12;

        public ObservableCollection<YourDeviceList> ControllerDevicesListData12
        {
            get { return _controllerDevicesListData12; }
            set { _controllerDevicesListData12 = value; }
        }

        
        private Plugin.BLE.Abstractions.Contracts.IAdapter adapter;

        private bool _IsBusyIsLoader;
        public bool IsBusyIsLoader
        {
            get { return _IsBusyIsLoader; }
            set { SetProperty(ref _IsBusyIsLoader, value); }
        }
        private bool _IsActivate;
        public bool IsActivate
        {
            get { return _IsActivate; }
            set { SetProperty(ref _IsActivate, value); }
        }

        public async Task bluetoothData()
        {
            await LocationPermission();
            var ble = CrossBluetoothLE.Current;
            var state = ble.State;
            var adapter = CrossBluetoothLE.Current.Adapter;
            if(!CrossBluetoothLE.Current.IsOn)
            {
                IsActivate = true;
                return;
            }
            else
            {
                IsActivate = false;
            }
            
            adapter.DeviceDiscovered += (s, a) =>
            {
                object n = a.Device.NativeDevice;
                string DeviceName = a.Device.Name;
                if (DeviceName == null)
                {
                    ControllerDevicesListData12.Add(new YourDeviceList { MacAddress = n, DeviceName = "NULL" });
                }
                else
                {
                    ControllerDevicesListData12.Add(new YourDeviceList { MacAddress = n, DeviceName = DeviceName });
                }
            };
            await Task.Delay(2000);
            
            if (!adapter.IsScanning)
            {
                IsBusyIsLoader = true;
                await adapter.StartScanningForDevicesAsync();
            }
        }

        public async Task LocationPermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();
            if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                var state = await App.Current.MainPage.DisplayAlert("Location Permission", "May we use Bluetooth and location services to find nearby devices?", "Proceed", "No Thanks");

                if (state)
                {
                    status = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();

                    Console.WriteLine("PermissionStatus=" + status);
                }
            }
        }

        public Command ActivateBluetoothCommand
        {
            get
            {
                return new Command(OnActivateBluetoothCommandClick);
            }
        }
        private async void OnActivateBluetoothCommandClick(object obj)
        {
            try
            {
                var networkProfiles = Connectivity.ConnectionProfiles;
                if (!networkProfiles.Contains(ConnectionProfile.Bluetooth))
                {
                    IsActivate = true;
                    await App.Current.MainPage.DisplayAlert("Bluetooth Permission", "Please turn on your Bluetooth", "Ok");
                    await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();

                }
                if (networkProfiles.Contains(ConnectionProfile.Bluetooth))
                {
                    IsActivate = false;
                }
                
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public Command<YourDeviceList> SelectBluetoothCommand
        {
            get
            {
                return new Command<YourDeviceList>(OnSelectBluetoothCommandClicked);
            }
        }
        private async void OnSelectBluetoothCommandClicked(YourDeviceList obj)
        {
            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new AddDeviceSuccessPage(ControllerData, ControllerDevicesListData1[0], obj));
        }

    }
}


