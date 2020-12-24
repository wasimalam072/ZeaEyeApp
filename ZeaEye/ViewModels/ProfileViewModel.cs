using System;
using Xamarin.Forms;

namespace ZeaEye.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel()
        {
            Title = "Profile";
        }

        private bool _EditTimeVisible = false;

        public bool EditTimeVisible
        {
            get
            {
                return _EditTimeVisible;
            }
            set
            {
                _EditTimeVisible = value; RaisePropertyChanged();
            }
        }

        private bool _EditTimeHide = true;

        public bool EditTimeHide
        {
            get
            {
                return _EditTimeHide;
            }
            set
            {
                _EditTimeHide = value; RaisePropertyChanged();
            }
        }

        #region Update Profile 
        public Command UpdateCommand
        {
            get
            {
                return new Command(OnUpdateCommandClicked);
            }
        }
        private void OnUpdateCommandClicked(object obj)
        {
            EditTimeVisible = false;
            EditTimeHide = true;
        }
        #endregion

        #region Edit Profile 
        public Command EditCommand
        {
            get
            {
                return new Command(OnEditCommandClicked);
            }
        }
        private void OnEditCommandClicked(object obj)
        {
            EditTimeVisible = true;
            EditTimeHide = false;
        }
        #endregion
    }
}
