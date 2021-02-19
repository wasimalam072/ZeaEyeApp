using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedControllerPage : ContentPage
    {
        public SelectedControllerPage(object Devicelistdata)
        {
            InitializeComponent();
            BindingContext = new SelectedControllerViewModel(Devicelistdata);
        }
    }
}