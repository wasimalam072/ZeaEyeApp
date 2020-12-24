using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeaEye.Models;
using ZeaEye.ViewModels;
using ZeaEye.Views;

namespace ZeaEye.Views
{
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
        }
    }
}