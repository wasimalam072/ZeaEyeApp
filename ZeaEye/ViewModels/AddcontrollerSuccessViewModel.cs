using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeaEye.API.Services;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class AddcontrollerSuccessViewModel : BaseViewModel
    {
        BaseApiServices baseApiServices;
        string[] Data = null;

        public AddcontrollerSuccessViewModel(string[] data)
        {
            baseApiServices = new BaseApiServices();
            Data = data;
            Title = "Add a new Controller";
            ControllerIdValue = Data[0];
            partnerid = Application.Current.Properties["PartneId"].ToString();
            contollerid = Data[2];

        }
        private string _ControllerIdValue;

        public string ControllerIdValue
        {
            get { return _ControllerIdValue; }
            set { _ControllerIdValue = value; RaisePropertyChanged(); }
        }
        string contollerid;
        string partnerid;
        public Command Devicelistcommand
        {
            get
            {
                return new Command(OnDevicelistcommandScreenClicked);
            }
        }
        private async void OnDevicelistcommandScreenClicked(object obj)
        {
            UserDialogs.Instance.ShowLoading("Please wait...");
            //string DocumentId = "";
            //if (string.IsNullOrEmpty(Application.Current.Properties["PartneId"].ToString()))
            //{
            //    var creatpartnewr = await baseApiServices.CreatePartnerId(Application.Current.Properties["Email"].ToString());
            //    if (!string.IsNullOrEmpty(creatpartnewr.partnerId))
            //    {
            //        Application.Current.Properties["PartneId"] = partnerid = creatpartnewr.partnerId;
            //        string DocID = Application.Current.Properties["DocValue"].ToString();
            //            string[] authorsList = DocID.Split('/');
            //        for(var i=0;i<=authorsList.Length-1;i++)
            //        {
            //            DocumentId= authorsList[authorsList.Length - 1];
            //        }
            //         var UpdatePartnerId = await baseApiServices.UpdatePartnerId(DocumentId, Application.Current.Properties["PartneId"].ToString());
            //    }
            //}

            var res = await baseApiServices.SaveController(contollerid, partnerid);
            if (res != "Connected")
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("Please Contact Admin", "There is Some Problem with the Controller", "ok");
                return;
            }

            UserDialogs.Instance.HideLoading();
            MainView.Instance.Detail = new NavigationPage(new YourDevicelistPage());
        }
        public Command BackFromToAddDevicecommand
        {
            get
            {
                return new Command(BackFromToAddDeviceScreen);
            }
        }
        private async void BackFromToAddDeviceScreen(object obj)
        {
            (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.RemovePage((Application.Current.MainPage as MasterDetailPage).Detail.Navigation.NavigationStack[(Application.Current.MainPage as MasterDetailPage).Detail.Navigation.NavigationStack.Count - 2]);
            _ = (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
        }
    }
}
