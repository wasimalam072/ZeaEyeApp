using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ZeaEye.Models;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ItemsViewModel()
        {
            Title = "Your Device";
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
            try
            {
                await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new ItemDetailPage());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}