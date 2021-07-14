using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace ChargEVCompanionApp.ViewModels
{
    public class RegisterUserViewModel : ViewModelBase
    {

        private string email = string.Empty;

        public string Email { get => email; set => SetProperty(ref email, value); }

        private string password = string.Empty;

        public string Password { get => password; set => SetProperty(ref password, value); }

        private string confirmPassword = string.Empty;

        public string ConfirmPassword { get => confirmPassword; set => SetProperty(ref confirmPassword, value); }

        public Command RegisterCommand { get; private set; }
        //public Command<Users> RegisterCommand { get; private set; }

        public RegisterUserViewModel()
        {
            Title = "Register";
            RegisterCommand = new Command(Register);
        }

        private async void Register(object parameter)
        {
            Users input = (Users)parameter;
            string pw = input.Password;
            string confirmpw = confirmPassword;


            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(confirmPassword))
            {
                bool passwordmatch = CheckPassword(pw, confirmpw);
                if (passwordmatch)
                {
                    bool canRegister = await CheckRegister(input);
                    if (canRegister)
                    {
                        await UserService.RegisterUser(input);
                        await App.Current.MainPage.DisplayAlert("Registration requested", "Please wait for approval", "OK");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Record exists! Please login", "OK"); //change to shell
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Password not matched", "OK");//change to shell
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Empty fields", "OK");//change to shell
            }
        }



        public async Task<bool> CheckRegister(Users user)
        {
            var record = (await App.MobileService.GetTable<Users>().Where(u => u.Email == user.Email).ToListAsync()).Count; //check existing data

            if (record > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool CheckPassword(string pw, string confirmpw)
        {
            if (!string.IsNullOrWhiteSpace(pw) && !string.IsNullOrEmpty(confirmpw))
            {
                if (pw == confirmpw)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
