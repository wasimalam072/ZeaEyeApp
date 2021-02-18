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
            
        }
        public ItemDetailPage(string ValueQR)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel(ValueQR);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://zeaeye.com/"));
        }
    }
}