using System;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
                Xamarin.Essentials.VersionTracking.Track();
                auth = DependencyService.Get<IAuth>();
                DependencyService.Register<MockDataStore>();
                Device.StartTimer(TimeSpan.FromSeconds(2), () =>
                {
                    if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
                    {
                        Application.Current.MainPage = new InternetCheckPage();
                    }
                    return false;
                });
                Xamarin.Essentials.Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

                if (auth.IsSignIn())
                {
                    MainPage = new MainView();
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Connectivity_ConnectivityChanged(object sender, Xamarin.Essentials.ConnectivityChangedEventArgs e)
        {
            if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
            {
                Application.Current.MainPage = new InternetCheckPage();
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

