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

        public bool IsAdmin { get => isAdmin; set => SetProperty(ref isAdmin, value); }

        public AppShellViewModel()
        {
            //MessagingCenter.Subscribe<LoginPage>(this, message: "admin", (sender) =>
            //  {
            //      IsAdmin = true;
            //  });
            //MessagingCenter.Subscribe<LoginPage>(this, message: "user", (sender) =>
            //{
            //    IsAdmin = false; ;
            //});
            string role = App.globaluser.Role;
            if (role == "Admin")
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }
        }
    }
}
