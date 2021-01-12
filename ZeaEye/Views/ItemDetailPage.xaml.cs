using System;
using System.ComponentModel;
using Xamarin.Forms;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://zeaeye.com/"));
        }
    }
}