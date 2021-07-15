using ChargEVCompanionApp.Views;
using ChargEVCompanionApp.Views.AdminPages;
using ChargEVCompanionApp.Views.UserPages;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ChargEVCompanionApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddNewsPage),
                typeof(AddNewsPage));

            Routing.RegisterRoute(nameof(RegisterUserPage),
                typeof(RegisterUserPage));

            Routing.RegisterRoute(nameof(LoginPage),
                typeof(LoginPage));

            Routing.RegisterRoute(nameof(NewFAQPage),
                typeof(NewFAQPage));

            Routing.RegisterRoute(nameof(MemberRegisterPage),
                typeof(MemberRegisterPage));

            Routing.RegisterRoute(nameof(PassPaymentPage),
                typeof(PassPaymentPage));
        }

    }
}
