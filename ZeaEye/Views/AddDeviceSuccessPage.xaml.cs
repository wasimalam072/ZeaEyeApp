using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.API.Models.Response;
using ZeaEye.Models;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDeviceSuccessPage : ContentPage
    {
        public AddDeviceSuccessPage(ObservableCollection<Controller> Devicelistdata, YourTypeDeviceList BandType, YourDeviceList YourDeviceListDataValue)
        {
            InitializeComponent();
            BindingContext = new AddDeviceSuccessViewModel(Devicelistdata, BandType, YourDeviceListDataValue);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://zeaeye.com/"));
        }
    }
}