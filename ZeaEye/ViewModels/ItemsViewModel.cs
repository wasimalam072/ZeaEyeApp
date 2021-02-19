using Xamarin.Forms;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ItemsViewModel()
        {
            Title = "Your Devices";
        }

        public Command FrameCommand
        {
            get
            {
                return new Command(OnFrameCommandClicked);
            }
        }
        private async void OnFrameCommandClicked(object obj)
        {
            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new ItemDetailPage(null));
        }
    }
}