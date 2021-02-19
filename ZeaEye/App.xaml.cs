using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZeaEye.Services;
using ZeaEye.Views;

namespace ZeaEye
{
    public enum AppState
    {
        Undefinded,
        Foreground,
        Background
    }
    public partial class App : Application
    {
        public static AppState State = AppState.Undefinded;
        private IAuth auth;
        public App()
        {
            try
            {
                InitializeComponent();
                Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
                VersionTracking.Track();
                auth = DependencyService.Get<IAuth>();
                DependencyService.Register<MockDataStore>();

                if (auth.IsSignIn())
                {
                    MainPage = new MainView();
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Connectivity_ConnectivityChanged(object sender, Xamarin.Essentials.ConnectivityChangedEventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                App.Current.MainPage.Navigation.PushModalAsync(new InternetCheckPage());
            }
            else
            {
                App.Current.MainPage.Navigation.PopModalAsync();
            }
        }

        protected override void OnStart()
        {
            State = AppState.Foreground;
        }

        protected override void OnSleep()
        {
            State = AppState.Background;
        }

        protected override void OnResume()
        {
            State = AppState.Foreground;
        }
    }
}

