using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.ViewModels;
using ChargEVCompanionApp.Views;
using ChargEVCompanionApp.Views.UserPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static async Task Update(Users user)
        {
            await App.MobileService.GetTable<Users>().UpdateAsync(user);
        }

        public static async Task<bool> ValidateLogin(string email, string password)
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
                            
                            return true;
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "No assigned role!", "OK");
                            return false;
                        }
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Wrong password!", "OK");
                        return false;
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "User not active!", "OK");
                    return false;
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "User not exist!", "OK");
                return false;
            }
        }

        

        public static async Task<IEnumerable<Users>> GetRequests()
        {
            //await Init();

            var users = await App.MobileService.GetTable<Users>().Where(u => u.IsActive == false).ToListAsync();

            return users;
        }
    }
}
