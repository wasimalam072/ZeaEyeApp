using Xamarin.Forms;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
        }
    }
}