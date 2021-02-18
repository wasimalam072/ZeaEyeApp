using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeaEye.API.Services;
using ZeaEye.Services;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class AddcontrollerSuccessViewModel : BaseViewModel
    {
        BaseApiServices baseApiServices;
        private IAuth auth;
        string[] Data = null;

        public AddcontrollerSuccessViewModel(string[] data)
        {
            baseApiServices = new BaseApiServices();
            auth = DependencyService.Get<IAuth>();
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
            var DocumentId = "";
            string userid = auth.GetUserId();
            var CheckingController = await baseApiServices.CheckControllerMapingExisting(contollerid, partnerid, true);
            Application.Current.Properties["ControllerExist"] = CheckingController.Item1;
            if (!string.IsNullOrEmpty(Application.Current.Properties["ControllerExist"].ToString()))
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("Please Contact Admin", "There is Some Problem with the Controller", "ok");
            }
            else
            {
                var creatpartnewr = await baseApiServices.SaveControllerDocument(contollerid, partnerid, userid, true);
                string DocValue = CheckingController.Item2;
                string DocID = DocValue;
                string[] authorsList = DocID.Split('/');
                for (var i = 0; i <= authorsList.Length - 1; i++)
                {
                    DocumentId = authorsList[authorsList.Length - 1];
                }
                var UpdatePartnerId = await baseApiServices.UpdateControllerMapping(DocumentId, true);
                var res = await baseApiServices.SaveController(contollerid, partnerid);
                if (res != "Connected")
                {
                    UserDialogs.Instance.HideLoading();
                    await Application.Current.MainPage.DisplayAlert("Please Contact Admin", "Controller already mappped", "ok");
                }
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
