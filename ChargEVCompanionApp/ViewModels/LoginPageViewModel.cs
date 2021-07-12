using ChargEVCompanionApp.Models;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChargEVCompanionApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {

        private string email;

        public string Email { get => email; set => SetProperty(ref email, value); }

        private Users user;

        public Users User { get => user; set => SetProperty(ref user, value); }

        private Command loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new Command(Login);
                }

                return loginCommand;
            }
        }

        private void Login()
        {
        }

        private Command registerNavigationCommand;

        public ICommand RegisterNavigationCommand
        {
            get
            {
                if (registerNavigationCommand == null)
                {
                    registerNavigationCommand = new Command(RegisterNavigation);
                }

                return registerNavigationCommand;
            }
        }

        private void RegisterNavigation()
        {
        }

        private string password;

        public string Password { get => password; set => SetProperty(ref password, value); }
    }
}
