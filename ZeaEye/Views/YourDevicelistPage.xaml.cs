using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.API.Models.Response;
using ZeaEye.API.Services;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YourDevicelistPage : ContentPage
    {
        BaseApiServices baseApiServices;
        public YourDevicelistPage()
        {
            InitializeComponent();
            baseApiServices = new BaseApiServices();
            BindingContext = new YourDevicelistViewModel();
        }

        //private async void SelectedDevicesList_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new SelectedControllerPage());
        //}

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    var layout = sender as Button;
        //    var model = layout.BindingContext as Controller;
        //    var result = await baseApiServices.SaveDevice(model.controllerId, model.bms.ToString(), model.serialNumber);
        //    await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new SelectedControllerPage());
        //}
    }
}