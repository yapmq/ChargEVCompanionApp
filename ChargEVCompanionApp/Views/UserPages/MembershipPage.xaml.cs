using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
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
    public partial class MembershipPage : ContentPage
    {
        public MembershipPage()
        {
            InitializeComponent();

            GetMember();
        }

        public async void GetMember()
        {
            await TestMember();
        }


        async Task TestMember()
        {
            Memberships test = await MembershipServices.IsMemberActive();

            if (test == null)
            {
                SubLabel.Text = "None";
                timeLabel.Text = "--";
            }
            else
            {
                SubLabel.Text = test.SubscriptionType.ToString();
                timeLabel.Text = test.EndTime.ToString("dd/MM/yyyy h: mm tt");
                GetButton.IsEnabled = false;
            }
        }

        private void GetButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"{nameof(MemberRegisterPage)}");
        }
    }
}