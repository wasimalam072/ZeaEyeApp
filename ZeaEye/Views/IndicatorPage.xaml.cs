using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndicatorPage : ContentPage
    {
        public IndicatorPage(bool IsErrorcode = false, string condata = null)
        {
            InitializeComponent();
            BindingContext = new IndicatorViewModel(IsErrorcode, condata);
        }
        protected override bool OnBackButtonPressed()
        {
            {
                return true;
            }
        }
    }
}