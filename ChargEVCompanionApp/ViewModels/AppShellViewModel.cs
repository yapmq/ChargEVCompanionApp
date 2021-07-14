using ChargEVCompanionApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {

        private bool isAdmin;

        //public bool IsAdmin { get => isAdmin; set => SetProperty(ref isAdmin, value); }

        public bool IsAdmin
        {
            get { return isAdmin; }
            set
            {
                isAdmin = value;
                OnPropertyChanged();
            }
        }

        private bool isUser;

        public bool IsUser
        {
            get { return isUser; }
            set
            {
                isUser = value;
                OnPropertyChanged();
            }
        }




        public AppShellViewModel()
        {
            MessagingCenter.Subscribe<LoginPageViewModel>(this, message: "admin", (sender) =>
            {
                IsAdmin = true;
                IsUser = false;

            });

            MessagingCenter.Subscribe<LoginPageViewModel>(this, message: "user", (sender) =>
            {
                IsAdmin = false;
                IsUser = true;
            });
        }




        //void Validate()
        //{

        //}
        //{
        //    string role = App.globaluser.Role;
        //    if (role == "Admin")
        //    {
        //        isAdmin = true;
        //    }
        //    else
        //    {
        //        isAdmin = false;
        //    }
        //}
    }
}

