using System;
using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZeaEye.API.Services;
using ZeaEye.Services;
using ZeaEye.Views;

namespace ZeaEye.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        BaseApiServices baseApiServices;
        private IAuth auth;
        public ProfileViewModel()
        {
            Title = "Profile";
            baseApiServices = new BaseApiServices();
            auth = DependencyService.Get<IAuth>();
            GetInformationOfUser();
        }

        private bool _EditTimeVisible = false;

        public bool EditTimeVisible
        {
            get { return _EditTimeVisible; }
            set { _EditTimeVisible = value; RaisePropertyChanged();}
        }

        private bool _EditTimeHide = true;

        public bool EditTimeHide
        {
            get { return _EditTimeHide; }
            set { _EditTimeHide = value; RaisePropertyChanged(); }
        }

        #region Full Name
        string _FullName = string.Empty;
        public string FullName
        {
            get { return _FullName; }
            set { SetProperty(ref _FullName, value); }
        }
        #endregion

        #region Email Id
        string _EmailId = string.Empty;
        public string EmailId
        {
            get { return _EmailId; }
            set { SetProperty(ref _EmailId, value); }
        }
        #endregion

        #region Mobile Number
        string _MobileNumber = string.Empty;
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { SetProperty(ref _MobileNumber, value); }
        }
        #endregion

        #region Mobile Number
        string _AlternetMobileNumber = string.Empty;
        public string AlternetMobileNumber
        {
            get { return _AlternetMobileNumber; }
            set { SetProperty(ref _AlternetMobileNumber, value); }
        }
        #endregion

        #region Profile Screen View
        public Command ProfileViewCommand
        {
            get { return new Command(OnProfileViewCommandClicked); }
        }

        private void OnProfileViewCommandClicked(object obj)
        {
            Application.Current.MainPage.DisplayAlert("Check", "Click Command", "Ok");
        }
        #endregion

        #region Update Profile 
        public Command UpdateCommand
        {
            get { return new Command(OnUpdateCommandClicked); }
        }
        private void OnUpdateCommandClicked(object obj)
        {
            EditTimeVisible = false;
            EditTimeHide = true;
            //UpdateInformationOfUser();
        }
        #endregion

        #region Update user Infomrtaion
        public async void UpdateInformationOfUser()
        {
            UserDialogs.Instance.ShowLoading("Please wait...");
            string DocumentId = "";
            string userid = auth.GetUserId();
            var partner = await baseApiServices.GetPartnerId(userid);
            string DocValue = partner.Item2;
            string DocID = DocValue;
            string[] authorsList = DocID.Split('/');
            for (var i = 0; i <= authorsList.Length - 1; i++)
            {
                DocumentId = authorsList[authorsList.Length - 1];
            }
            var UserInformation = await baseApiServices.UpdateUserInformationId(DocumentId, FullName, MobileNumber, AlternetMobileNumber);
            UserDialogs.Instance.HideLoading();
        }
        #endregion

        #region Edit Profile 
        public Command EditCommand
        {
            get { return new Command(OnEditCommandClicked);  }
        }
        private void OnEditCommandClicked(object obj)
        {
            EditTimeVisible = true;
            EditTimeHide = false;
            GetInformationOfUser();
        }
        #endregion

        #region Get user Infomrtaion
        public async void GetInformationOfUser()
        {
            UserDialogs.Instance.ShowLoading("Please wait...");
            string userid = auth.GetUserId();
            var UserInformation = await baseApiServices.GetUserInformation(userid);
            EmailId = UserInformation[0].Document.Fields.Email.StringValue;
            FullName = UserInformation[0].Document.Fields.Name.StringValue;
            MobileNumber = UserInformation[0].Document.Fields.MobileNumber.StringValue;
            AlternetMobileNumber = UserInformation[0].Document.Fields.AlternetMobileNumber.StringValue;
            UserDialogs.Instance.HideLoading();
        }
        #endregion

        #region Change Password
        public Command ChangePasswordCommand
        {
            get { return new Command(OnChangePasswordCommandClicked); }
        }
        private async void OnChangePasswordCommandClicked(object obj)
        {
            await(Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new PasswordChangePage());
        }
        #endregion
    }
}
