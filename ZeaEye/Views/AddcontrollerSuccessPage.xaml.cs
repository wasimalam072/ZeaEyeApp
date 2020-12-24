using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //protected async override void OnAppearing()
        //{
        //    (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.RemovePage((Application.Current.MainPage as MasterDetailPage).Detail.Navigation.NavigationStack[(Application.Current.MainPage as MasterDetailPage).Detail.Navigation.NavigationStack.Count - 2]);

        //    await(Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
        //    base.OnAppearing();
        //}
    }
}