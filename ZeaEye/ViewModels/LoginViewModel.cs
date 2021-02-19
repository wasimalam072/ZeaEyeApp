﻿using System.ComponentModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZeaEye.API.Services;
using ZeaEye.Services;
using ZeaEye.Views;
using static Xamarin.Essentials.Permissions;

namespace ZeaEye.ViewModels
{
    public class LoginViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private IAuth auth;
        BaseApiServices baseApiServices;
        public LoginViewModel()
        {
            Title = "Log In";
            baseApiServices = new BaseApiServices();
            auth = DependencyService.Get<IAuth>();
            VersionNumberDisplay = VersionTracking.CurrentVersion;
            _=StoragePermission();
        }

        public async Task StoragePermission()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.Camera());
            if (status != PermissionStatus.Granted)
            {
                await StoragePermission();
            }
        }

        #region EmailID
        private string _EmailId;
        public string EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; PropertyChanged(this, new PropertyChangedEventArgs("EmailId"));}
        }
        #endregion

        #region Password
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; PropertyChanged(this, new PropertyChangedEventArgs("Password")); }
        }
        #endregion

        #region LogInCommand
        public Command LoginCommand
        {
            get { return new Command(OnLoginClicked); }
        }

        private async void OnLoginClicked(object obj)
        {
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            if (current == NetworkAccess.Internet)
            {
                if (string.IsNullOrEmpty(EmailId) && string.IsNullOrEmpty(Password))
                {
                    await UserDialogs.Instance.AlertAsync("Email Id and Password are mandatory.", "Empty", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(EmailId))
                {
                    await UserDialogs.Instance.AlertAsync("Email Id is mandatory.", "Empty", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(Password))
                {
                    await UserDialogs.Instance.AlertAsync("Password is mandatory.", "Empty", "Ok");
                    return;
                }
                Application.Current.Properties["DocValue"] = "";
                Application.Current.Properties["Email"] = "";
                UserDialogs.Instance.ShowLoading("Please wait...");
                string token = await auth.LogInWithEmailAndPassword(EmailId, Password);
                if (token != string.Empty)
                {
                    string userid = auth.GetUserId();
                    string DocumentId = "";
                    var partner = await baseApiServices.GetPartnerId(userid);
                    Application.Current.Properties["PartneId"] = partner.Item1; 
                    if (string.IsNullOrEmpty(Application.Current.Properties["PartneId"].ToString()))
                    {
                            var creatpartnewr = await baseApiServices.CreatePartnerId(EmailId);
                            Application.Current.Properties["PartneId"] = creatpartnewr.partnerId;
                            string DocValue = partner.Item2;
                            string DocID = DocValue;
                            string[] authorsList = DocID.Split('/');
                            for (var i = 0; i <= authorsList.Length - 1; i++)
                            {
                                DocumentId = authorsList[authorsList.Length - 1];
                            }
                            var UpdatePartnerId = await baseApiServices.UpdatePartnerId(DocumentId, Application.Current.Properties["PartneId"].ToString());

                    }
                    Application.Current.Properties["Email"] = EmailId;
                    Application.Current.MainPage = new MainView();
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await UserDialogs.Instance.AlertAsync("Email or Password are incorrect.", "Authentication Fail", "Ok");
                }
                UserDialogs.Instance.HideLoading();
            }
            else
            {
                await UserDialogs.Instance.AlertAsync("Internet connection required.", "Internet", "Ok");
            }
        }
        #endregion

        #region MoveToSignUpScreen
        public Command SignInScreenCommand
        {
            get { return new Command(OnSignInScreenClicked); }
        }
        private void OnSignInScreenClicked(object obj)
        {
            Application.Current.MainPage = new NavigationPage(new SignUpPage());
        }
        #endregion

        public async Task<PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission)
           where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }
            return status;
        }
    }
}
