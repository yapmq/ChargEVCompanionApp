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

        private string email;

        public string Email { get => email; set => SetProperty(ref email, value); }

        private string password;

        public string Password { get => password; set => SetProperty(ref password, value); }

        private string confirmPassword;

        public string ConfirmPassword { get => confirmPassword; set => SetProperty(ref confirmPassword, value); }

        public Command RegisterCommand { get; private set; }


        public RegisterUserViewModel()
        {
            Title = "Register";
            RegisterCommand = new Command(Register);
        }

        private async void Register(object parameter)
        {
            try
            {
                Users input = (Users)parameter;

                if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(confirmPassword))
                {
                    if (password == confirmPassword)
                    {
                        //bool canRegister = await CheckRegister(input);
                        if (await CheckRegister(input))
                        {
                            await UserService.RegisterUser(input);
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "Record exists! Please login", "OK");
                        }
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Password not matched", "OK");
                    }

                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Empty Fields", "OK");
                }
            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Error", ex.ToString(), "OK");
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
        //private Command registerCommand;

        //public ICommand RegisterCommand
        //{
        //    get
        //    {
        //        if (registerCommand == null)
        //        {
        //            registerCommand = new Command(Register);
        //        }

        //        return registerCommand;
        //    }
        //}

        //public Command RegisterCommand { get; }

        // private void Register(object parameter)
        //{
        //    
        //}


        ////public ICommand RegisterCommand
        ////{
        ////    get
        ////    {
        ////        if (registerCommand == null)
        ////        {
        ////            registerCommand = new Command(Register);
        ////        }

        ////        return registerCommand;
        ////    }
        ////}

        //async Task Register()
        //{
        //    if(!string.IsNullOrWhiteSpace(user.email) && !string.IsNullOrWhiteSpace(user.password) && !string.IsNullOrWhiteSpace(user.confirmPassword))
        //    {
        //        if (user.password == user.confirmPassword)
        //        {
        //            await CheckRegister(user);
        //        }
        //        else
        //        {
        //            await Shell.Current.DisplayAlert("Error", "Password not matched", "OK");
        //        }

        //    }
        //}
    }
}
