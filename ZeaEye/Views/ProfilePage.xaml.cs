using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
        }
    }
}
