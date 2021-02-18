using System;
using Acr.UserDialogs;
using Xamarin.Forms;
using ZeaEye.Services;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class PasswordChangeViewModel : BaseViewModel
    {
        private IAuth auth;
        public PasswordChangeViewModel()
        {
            Title = "Change Password";
            auth = DependencyService.Get<IAuth>();
        }

        private bool _EditTimeVisible = false;

        public bool EditTimeVisible
        {
            get { return _EditTimeVisible; }
            set { _EditTimeVisible = value; RaisePropertyChanged(); }
        }

        private bool _EditTimeHide = true;

        public bool EditTimeHide
        {
            get { return _EditTimeHide; }
            set { _EditTimeHide = value; RaisePropertyChanged(); }
        }


        #region Verify Email Id
        string _VerfyEmailId = string.Empty;
        public string VerfyEmailId
        {
            get { return _VerfyEmailId; }
            set { SetProperty(ref _VerfyEmailId, value); }
        }
        #endregion

        #region Update Password
        string _UpdatePassword = string.Empty;
        public string UpdatePassword
        {
            get { return _UpdatePassword; }
            set { SetProperty(ref _UpdatePassword, value); }
        }
        #endregion

        #region Verfiy Email
        public Command VerifyEmailCommand
        {
            get { return new Command(OnVerifyEmailCommandClicked); }
        }
        private async void OnVerifyEmailCommandClicked(object obj)
        {
            if(Application.Current.Properties["Email"].ToString() == VerfyEmailId)
            {
                EditTimeVisible = true;
                EditTimeHide = false;
            }
            //if (string.IsNullOrEmpty(VerfyEmailId))
            //{
            //    await Application.Current.MainPage.DisplayAlert("Empty", "Email Id is mandatory.", "Ok");
            //    return;
            //}
            else
            {
                await Application.Current.MainPage.DisplayAlert("Email Id", "Email Id didn't match.", "Ok");
                return;
            }
        }
        #endregion

        #region Update Password
        public Command UpdatePasswordCommand
        {
            get { return new Command(OnUpdatePasswordCommandClicked); }
        }
        private async void OnUpdatePasswordCommandClicked(object obj)
        {
            UserDialogs.Instance.ShowLoading("Please wait...");
            if (string.IsNullOrEmpty(UpdatePassword))
            {
                await Application.Current.MainPage.DisplayAlert("Empty", "Password is mandatory.", "Ok");
                return;
            }
            if (UpdatePassword?.Length <= 6)
            {
                await Application.Current.MainPage.DisplayAlert("Validation", "Password must be grater than 7 characters.", "Ok");
                UserDialogs.Instance.HideLoading();
                return;
            }
            else
            { 
                var result =  auth.GetCurrentUser(UpdatePassword);
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("Update", "Password has updated.", "Ok");
                Application.Current.MainPage = new LoginPage();
            }
            UserDialogs.Instance.HideLoading();
        }
        #endregion
    }
}
