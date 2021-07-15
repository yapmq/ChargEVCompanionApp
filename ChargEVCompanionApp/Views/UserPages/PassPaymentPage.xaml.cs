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
    public partial class PassPaymentPage : ContentPage
    {
        string validUntil;
        DateTimeOffset Startvalid = DateTimeOffset.Now;
        string validNow = DateTimeOffset.Now.ToString("dd/MM/yyyy h:mm tt");
        DateTimeOffset Endvalid;
        public PassPaymentPage(string pass, decimal price)
        {
            InitializeComponent();

            PassTypeLabel.Text = pass;
            priceLabel.Text = price.ToString();

            if (price.Equals(15.00m))
            {
                validUntil = DateTimeOffset.Now.AddDays(1).ToString("dd/MM/yyyy h:mm tt");
                Endvalid = DateTimeOffset.Now.AddDays(1);
                ValidTimeLabel.Text = $"{validNow} until {validUntil}";
            }
            else if (price.Equals(100.00m))
            {
                validUntil = DateTimeOffset.Now.AddDays(7).ToString("dd/MM/yyyy h:mm tt");
                Endvalid = DateTimeOffset.Now.AddDays(7);
                ValidTimeLabel.Text = $"{validNow} until {validUntil}";
            }
            else if (price.Equals(420.00m))
            {
                validUntil = DateTimeOffset.Now.AddMonths(1).ToString("dd/MM/yyyy h:mm tt");
                Endvalid = DateTimeOffset.Now.AddMonths(7);
                ValidTimeLabel.Text = $"{validNow} until {validUntil}";
            }

        }

        private async void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(CvvEntry.Text) && !string.IsNullOrWhiteSpace(CardEntry.Text))
            {
                Memberships member = new Memberships();
                member.UserId = App.globaluser.Id;
                member.SubscriptionType = PassTypeLabel.Text;
                member.createdAt = Startvalid;
                member.EndTime = Endvalid;
                member.IsActive = true;

                await App.MobileService.GetTable<Memberships>().InsertAsync(member);
                await Shell.Current.DisplayAlert("Success!", "Your pass has been activated", "OK");
                await Shell.Current.GoToAsync("//MapPage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "Please fill in the empty fields", "OK");
            }

            
        }
    }
}