using System.ComponentModel;
using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZeaEye.API.Services;
using ZeaEye.Services;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class SignUpViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        BaseApiServices baseApiServices;
        private IAuth auth;
        public SignUpViewModel()
        {
            Title = "Sign In";
            baseApiServices = new BaseApiServices();
            auth = DependencyService.Get<IAuth>();
            VersionNumberDisplay = VersionTracking.CurrentVersion;
        }

        #region EmailID
        private string _EmailId;
        public string EmailId
        {
            get { return _EmailId; }
            set {  _EmailId = value; PropertyChanged(this, new PropertyChangedEventArgs("EmailId")); }
        }
        #endregion

        #region FirstName
        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; PropertyChanged(this, new PropertyChangedEventArgs("FirstName")); }
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

        #region SignUpCommand
        public Command SignUpCommand
        {
            get { return new Command(OnSignUpClicked); }
        }

        private async void OnSignUpClicked(object obj)
        {
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            if (current == NetworkAccess.Internet)
            {
                if (string.IsNullOrEmpty(EmailId) && string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(Password))
                {
                    await UserDialogs.Instance.AlertAsync("Email Id, FirstName and Password are mandatory.", "Empty", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(Password))
                {
                    await UserDialogs.Instance.AlertAsync("FirstName and Password are mandatory", "Empty", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(EmailId) && string.IsNullOrEmpty(Password))
                {
                    await UserDialogs.Instance.AlertAsync("Email Id and Password are mandatory.", "Empty", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(EmailId) && string.IsNullOrEmpty(FirstName))
                {
                    await UserDialogs.Instance.AlertAsync("Email Id and FirstName are mandatory.", "Empty", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(EmailId))
                {
                    await UserDialogs.Instance.AlertAsync("Email Id is mandatory.", "Empty", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(FirstName))
                {
                    await UserDialogs.Instance.AlertAsync("FirstName is mandatory.", "Empty", "Ok");
                    return;
                }
                if (string.IsNullOrEmpty(Password))
                {
                    await UserDialogs.Instance.AlertAsync("Password is mandatory.", "Empty", "Ok");
                    return;
                }
                if (Password?.Length <= 6)
                {
                    await UserDialogs.Instance.AlertAsync("Password must be grater than 7 characters.", "Validation", "Ok");
                    return;
                }
                UserDialogs.Instance.ShowLoading("Please wait...");
                var user = await auth.SignUpWithEmailAndPassword(EmailId, Password);
                string name = FirstName;
                Preferences.Set("UserName", FirstName);
                if (user == "E")
                {
                    await UserDialogs.Instance.AlertAsync("Email Id already exist.", "Error", "Ok");
                }
                else if (user == "EF")
                {
                    await UserDialogs.Instance.AlertAsync("Email Id is not correct format.", "Error", "Ok");
                }
                else if (user != "")
                {
                    string userid = auth.GetUserId();
                    var res1 = await baseApiServices.SaveDocument(EmailId, string.Empty, userid, name, string.Empty, string.Empty);
                    Application.Current.Properties["UserName"] = FirstName;
                    UserDialogs.Instance.HideLoading();
                    await UserDialogs.Instance.AlertAsync("Your account successfully created.", "Success", "Ok");
                    var signOut = auth.SignOut();
                    if (signOut)
                    {
                        Preferences.Set("PartneId", string.Empty);
                        //Application.Current.Properties["PartneId"] = "";
                        Application.Current.MainPage = new LoginPage();
                    }
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await UserDialogs.Instance.AlertAsync("Somthings went wrong, please try again.", "Error", "Ok");
                }
                UserDialogs.Instance.HideLoading();
            }
            else
            {
                await UserDialogs.Instance.AlertAsync("Internet connection required.", "Internet", "Ok");
            }
        }
        #endregion

        #region MoveToLogInScreen
        public Command LogInScreenCommand
        {
            get { return new Command(OnLogInScreenClicked); }
        }
        private void OnLogInScreenClicked(object obj)
        {
            Application.Current.MainPage = new LoginPage();
        }
        #endregion
    }
}
