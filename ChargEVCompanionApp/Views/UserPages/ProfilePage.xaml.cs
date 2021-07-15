using ChargEVCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChargEVCompanionApp.Views.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            EmailEntry.Text = App.globaluser.Email;
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if(PasswordEntry.Text == confirmPasswordEntry.Text)
            {
                Users user = (await App.MobileService.GetTable<Users>()
                        .Where(m => m.Id == App.globaluser.Id)
                        .ToListAsync()).FirstOrDefault();

                user.Password = PasswordEntry.Text;
                

                await App.MobileService.GetTable<Users>().UpdateAsync(user);
                await Shell.Current.DisplayAlert("Success!", "Profile updated.", "OK");
                PasswordEntry.Text = "";
                confirmPasswordEntry.Text = "";
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "Please make sure passwords are matched", "OK");
            }
        }

    }
}