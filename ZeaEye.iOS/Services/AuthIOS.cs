using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using ZeaEye.iOS.Services;
using ZeaEye.Services;
using Xamarin.Forms;
using Firebase.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(AuthIOS))]
namespace ZeaEye.iOS.Services
{
    public class AuthIOS : IAuth
    {
        public string GetCurrentUser(string UpdatePassword)
        {
            try
            {
                var user = Auth.DefaultInstance.CurrentUser;
                user.UpdatePasswordAsync(UpdatePassword);
                return user.Uid;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }

        public string GetUserId()
        {
            var user = Auth.DefaultInstance.CurrentUser;
            return user.Uid;
        }

        public bool IsSignIn()
        {
            var user = Auth.DefaultInstance.CurrentUser;
            return user != null;
        }

        public async Task<string> LogInWithEmailAndPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public bool SignOut()
        {
            try
            {
                _ = Auth.DefaultInstance.SignOut(out NSError error);
                return error == null;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<string> SignUpWithEmailAndPassword(string email, string password)
        {
            try
            {
                var newUser = await Auth.DefaultInstance.CreateUserAsync(email, password);
                return await newUser.User.GetIdTokenAsync();
            }
            catch(Exception e)
            {
                return string.Empty;
            }
        }
    }
}