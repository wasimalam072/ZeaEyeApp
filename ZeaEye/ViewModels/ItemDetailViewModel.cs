using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeaEye.API.Services;
using ZeaEye.Models;
using ZeaEye.Views;
using ZXing.Net.Mobile.Forms;

namespace ZeaEye.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        BaseApiServices baseApiServices;

        bool CheckBoolValue;
        public ItemDetailViewModel()
        {
            baseApiServices = new BaseApiServices();
            Title = "Add you first Controller";
        }
        private string _con;

        public string Con
        {
            get { return _con; }
            set { _con = value; RaisePropertyChanged(); }
        }
        public Command Frame1Command
        {
            get
            {
                return new Command(async () => await OnIndicatorScreenClicked(""));
            }
        }

        private async Task OnIndicatorScreenClicked(object obj)
        {
            if (string.IsNullOrEmpty(_con?.Trim()))
            {
                return;
            }
            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new IndicatorPage());
            var result = await baseApiServices.LocateController(Con);
            string condata = Con;

            if (result.IsErrorcode)
            {
                CheckBoolValue = result.IsErrorcode;
                string[] data = new string[3] { Con, result.partnerId, result.controllerId };
                await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new AddcontrollerSuccessPage(data));
            }
            else
            {
                await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new IndicatorPage(result.IsErrorcode, Con));
            }
        }
        public Command QRcodeCommand
        {
            get
            {
                return new Command(OnIndicatorScreenUsingScanClicked);
            }
        }
        private async void OnIndicatorScreenUsingScanClicked(object obj)
        {
            ZXingScannerPage scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += async (result) =>
            {
                Con = result.Text;

                scanPage.IsScanning = true;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
                    await OnIndicatorScreenClicked("");
                });
            };
            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(scanPage);
        }
    }
}
