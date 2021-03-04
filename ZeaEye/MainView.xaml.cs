using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.API.Services;
using ZeaEye.Services;
using ZeaEye.ViewModels;
using ZeaEye.Views;

namespace ZeaEye
{
    public partial class MainView : MasterDetailPage
    {
        BaseApiServices baseApiServices;
        public ListView ListView;
        public static MainView Instance; 
        private IAuth auth;
        public MainView()
        {
            try
            {
                InitializeComponent();
                Instance = this;
                auth = DependencyService.Get<IAuth>();
                baseApiServices = new BaseApiServices();
                BindingContext = new MainViewModel();
                Detail = new NavigationPage(new AboutPage());
                IsPresented = false;
            }
            catch(Exception ex)
            {

            }
        }

        private void Button_Clicked_Dashboard(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AboutPage());
            IsPresented = false;
        }

        private void Button_ClickedProfile(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ProfilePage());
            IsPresented = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Please wait...");
            var partnerid = Preferences.Get("PartneId", string.Empty);
            //var partnerid = Application.Current.Properties["PartneId"] as string;
            if (string.IsNullOrEmpty(partnerid))
            {
                Detail = new NavigationPage(new ItemsPage());
                IsPresented = false;
                UserDialogs.Instance.HideLoading();
                return;
            }
            var res = await baseApiServices.GetDevices(partnerid);
            if (res.controllers?.Count == 0)
            {
                Detail = new NavigationPage(new ItemsPage());
                IsPresented = false;
                UserDialogs.Instance.HideLoading();
            }
            else
            {
                Detail = new NavigationPage(new YourDevicelistPage());
                IsPresented = false;
                UserDialogs.Instance.HideLoading();
            }

        }

        private async void Button_Clicked_Help(object sender, EventArgs e)
        {
            await Browser.OpenAsync(new Uri("https://zeaeye.com/"));
            IsPresented = false;
        }

        private void Button_Clicked_Signout(object sender, EventArgs e)
        {
            
            try
            {
                var signOut = auth.SignOut();
                if (signOut)
                {
                    Preferences.Set("PartneId", string.Empty);
                    //Application.Current.Properties["PartneId"] = "";
                    Application.Current.Properties["Email"] = "";
                    Application.Current.MainPage = new LoginPage();
                    IsPresented = false;
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}