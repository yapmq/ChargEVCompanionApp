using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.ViewModels;
using ChargEVCompanionApp.Views.UserPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChargEVCompanionApp.Services
{
    public class UserService
    {
        public static async Task RegisterUser(Users user)
        {
            await App.MobileService.GetTable<Users>().InsertAsync(user);
        }

        public static async Task ValidateLogin(string email, string password)
        {
            var user = (await App.MobileService.GetTable<Users>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

            if (user != null)
            {
                if (user.IsActive == true)

                {
                    if (password == user.Password)
                    {
                        if (user.Role == "User" || user.Role == "Admin")
                        {
                            App.globaluser = user;

                            await Shell.Current.GoToAsync("//MapPage");
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "No assigned role!", "OK");
                        }
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Wrong password!", "OK");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "User not active!", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "User not exist!", "OK");
            }
        }
    }
}
