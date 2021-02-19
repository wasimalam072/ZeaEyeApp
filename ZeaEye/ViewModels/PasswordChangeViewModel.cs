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
            else
            {
                await UserDialogs.Instance.AlertAsync("Email Id didn't match.", "Email Id", "Ok");
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
                await UserDialogs.Instance.AlertAsync("Password is mandatory.", "Empty", "Ok");
                return;
            }
            if (UpdatePassword?.Length <= 6)
            {
                await UserDialogs.Instance.AlertAsync("Password must be grater than 7 characters.", "Validation", "Ok");
                UserDialogs.Instance.HideLoading();
                return;
            }
            else
            { 
                var result =  auth.GetCurrentUser(UpdatePassword);
                UserDialogs.Instance.HideLoading();
                await UserDialogs.Instance.AlertAsync("Password has updated.", "Update", "Ok");
                Application.Current.MainPage = new LoginPage();
            }
            UserDialogs.Instance.HideLoading();
        }
        #endregion
    }
}
