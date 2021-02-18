using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeReaderPage : ContentPage
    {
        BarcodeReaderViewModel _viewModel;

        public BarcodeReaderPage(Action<string> action)
        {
            InitializeComponent();
            _viewModel = (BarcodeReaderViewModel)(BindingContext = new BarcodeReaderViewModel(action));
            scannerOverlay.BindingContext = scannerOverlay;
            var timeSpan = TimeSpan.FromSeconds(3);
            var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
            options.TryInverted = true;
            scannerView.Options = options;

            Device.StartTimer(timeSpan, () =>
            {
                if (scannerView.IsScanning)
                {
                    scannerView.AutoFocus();
                }
                return true;
            });
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            _viewModel = BindingContext as BarcodeReaderViewModel;
            if (_viewModel != null)
            {
                _viewModel.OnFlashToggled += ToggleFlashIcon;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel != null)
            {
                _viewModel.IsScanning = true;
            }
        }

        protected override void OnDisappearing()
        {
            if (_viewModel != null)
            {
                _viewModel.IsScanning = false;
            }
            base.OnDisappearing();
        }

        void ToggleFlashIcon(bool isFlashOn)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                flashSwitchItem.Icon = isFlashOn ? "light_on.png" : "light_off.png";
            });
        }
    }
}