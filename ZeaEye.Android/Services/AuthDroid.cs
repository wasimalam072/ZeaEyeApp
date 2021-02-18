using System;
using System.Threading.Tasks;
using ZeaEye.Services;
using Xamarin.Forms;
using Firebase.Auth;
using ZeaEye.Droid.Services;
using Android.Gms.Extensions;

[assembly : Dependency(typeof(AuthDroid))]
namespace ZeaEye.Droid.Services
{
    public class AuthDroid : IAuth
    {

        public string GetUserId()
        {
            var user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
            return user.Uid;
        }

        public string GetCurrentUser(string UpdatePassword)
        {
            try
            {
                var user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
                user.UpdatePasswordAsync(UpdatePassword);
                return user.Uid;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }

        public bool IsSignIn()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            return user != null;
        }

        public async Task<string> LogInWithEmailAndPassword(string email, string password)
        {
            try
            {
                var newUser = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return newUser.ToString();
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
        }

        public bool SignOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<string> SignUpWithEmailAndPassword(string email, string password)
        {
            try
            {
                var newUser = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                return newUser.ToString();
            }
            catch(FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;    
            }
            catch(FirebaseAuthUserCollisionException e)
            {
                e.PrintStackTrace();
                return "E";
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return "EF";
            }
        }
    }
}