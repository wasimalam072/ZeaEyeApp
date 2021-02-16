using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using ZeaEye.Services;
using Acr.UserDialogs;
using ZeaEye.API.Services;

namespace ZeaEye.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        BaseApiServices baseApiServices;
        private IAuth auth;
        public MainViewModel()
        {
            try
            {
                auth = DependencyService.Get<IAuth>();
                baseApiServices = new BaseApiServices();
                VersionNumberDisplay = VersionTracking.CurrentVersion;
                GetUserName();
            }
            catch (Exception ex)
            {

            }
        }

        #region User Name Display
        string _UserNameDisplay = string.Empty;
        public string UserNameDisplay
        {
            get { return _UserNameDisplay; }
            set { SetProperty(ref _UserNameDisplay, value); }
        }
        #endregion


        public async void GetUserName()
        {
            try
            {
                string userid = auth.GetUserId();
                var UserInformation = await baseApiServices.GetUserInformation(userid);
                UserNameDisplay = UserInformation[0].Document.Fields.Name.StringValue;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
