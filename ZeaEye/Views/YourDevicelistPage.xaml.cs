using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
    }
}