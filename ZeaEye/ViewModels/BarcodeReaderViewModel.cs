using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ZeaEye.ViewModels
{
    public class BarcodeReaderViewModel : BaseViewModel
    {
        Action<string> _action;
        public BarcodeReaderViewModel(Action<string> action)
        {
            _action = action;
        }

        public event Action<bool> OnFlashToggled;

        ZXing.Result _scanResult;
        public ZXing.Result ScanResult
        {
            get => _scanResult;
            set => SetProperty(ref _scanResult, value);
        }

        bool _isScanning;
        public bool IsScanning
        {
            get => _isScanning;
            set => SetProperty(ref _isScanning, value);
        }

        bool _isTorchOn;
        public bool IsTorchOn
        {
            get => _isTorchOn;
            set
            {
                if (SetProperty(ref _isTorchOn, value))
                {
                    OnFlashToggled?.Invoke(_isTorchOn);
                }
            }
        }

        public Command OnScanResultCommand
        {
            get { return new Command(OnScanResultCommandClicked); }
        }

        private async void OnScanResultCommandClicked(object obj)
        {
            await OnScanResult();
        }

        public Command OnToggleCameraFlashCommand
        {
            get { return new Command(OnToggleCameraFlashCommandClicked); }
        }

        private void OnToggleCameraFlashCommandClicked(object obj)
        {
            IsTorchOn = !IsTorchOn;
        }

        async Task OnScanResult()
        {
            IsScanning = IsTorchOn = false;

            try
            {
                if (!string.IsNullOrWhiteSpace(ScanResult.Text))
                {
                    MainThread.BeginInvokeOnMainThread(async()=>{
                        await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
                        _action.Invoke(ScanResult.Text);
                    });
                    }
                else
                {
                    await UserDialogs.Instance.AlertAsync("The QR code value is not assigned.", "Empty", "Ok");
                }
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync("The QR Code value is not supported.", "Format", "Ok");
            }
            finally
            {
                IsScanning = true;
            }
        }
    }
}
