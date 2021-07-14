using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using ChargEVCompanionApp.Views;
using ChargEVCompanionApp.Views.UserPages;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {

        private string email = string.Empty;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged();
            }
        }

        private string password = string.Empty;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged();
            }
        }

        private Users user;

        public Users User { get => user; set => SetProperty(ref user, value); }


        public AsyncCommand LoginCommand { get; private set; }


        public LoginPageViewModel()
        {
            User = new Users();
            LoginCommand = new AsyncCommand(Login);
        }

        public async Task Login()
        {
            if (user != null)
            {
                if (!string.IsNullOrWhiteSpace(User.Email) && !string.IsNullOrWhiteSpace(User.Password))
                {
                    bool canlogin = await UserService.ValidateLogin(User.Email, User.Password);
                    if (canlogin)
                    {
                        string userRole = App.globaluser.Role.ToLower();

                        MessagingCenter.Send<LoginPageViewModel>(this,
                            (userRole == "admin") ? "admin" : "user"
                            );

                        await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
                    }
                    return;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Empty fields!", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Empty fields!", "OK");
            }
        }
    }
}

