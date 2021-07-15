using ChargEVCompanionApp.Models;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        public AsyncCommand LogoutCommand { get; }
        public MapViewModel()
        {
            LogoutCommand = new AsyncCommand(Logout);
        }
        async Task Logout()
        {
            Users user = new Users();
            App.globaluser = user;
            await Shell.Current.GoToAsync("//LoginPage");


        }
    }
}
