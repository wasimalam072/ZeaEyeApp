using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.ViewModels;

namespace ZeaEye.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedControllerPage : ContentPage
    {
        public SelectedControllerPage(object Devicelistdata)
        {
            InitializeComponent();
            BindingContext = new SelectedControllerViewModel(Devicelistdata);
        }
    }
}