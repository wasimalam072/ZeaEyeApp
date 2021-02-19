using Xamarin.Forms;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    public partial class PasswordChangePage : ContentPage
    {
        public PasswordChangePage()
        {
            InitializeComponent();
            BindingContext = new PasswordChangeViewModel();
        }
    }
}
