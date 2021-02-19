using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddcontrollerSuccessPage : ContentPage
    {
        public AddcontrollerSuccessPage(string[] data = null)
        {
            InitializeComponent();
            BindingContext = new AddcontrollerSuccessViewModel(data);
        }
        protected override bool OnBackButtonPressed()
        {
            (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.RemovePage((Application.Current.MainPage as MasterDetailPage).Detail.Navigation.NavigationStack[(Application.Current.MainPage as MasterDetailPage).Detail.Navigation.NavigationStack.Count - 2]);
            (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
            return true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://zeaeye.com/"));
        }
    }
}