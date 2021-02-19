using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectedDevicesPage : ContentPage
    {
        public ConnectedDevicesPage()
        {
            InitializeComponent();
            BindingContext = new ConnectedDevicesViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://zeaeye.com/"));
        }
    }
}