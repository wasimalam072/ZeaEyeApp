using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace ZeaEye.Views
{
    public partial class InternetCheckPage : ContentPage
    {
        public InternetCheckPage()
        {
            InitializeComponent();
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
        //    {
        //        UserDialogs.Instance.ShowLoading("Please wait...");
        //        await Task.Delay(2000);
        //        UserDialogs.Instance.HideLoading();
        //    }
        //    else
        //    {
        //        UserDialogs.Instance.ShowLoading("Please wait...");
        //        Application.Current.MainPage = new MainView();
        //        UserDialogs.Instance.HideLoading();
        //        MessagingCenter.Send("Reload", "Reload");
        //    }
        //}
    }
}