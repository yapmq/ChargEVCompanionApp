using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChargEVCompanionApp.Services
{
    public class UserService 
    {
        public static async Task RegisterUser(Users user)
        {
            await App.MobileService.GetTable<Users>().InsertAsync(user);
        }
    }
}
