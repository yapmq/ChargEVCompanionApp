using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChargEVCompanionApp.Views.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountRequestPage : ContentPage
    {
        public AccountRequestPage()
        {
            InitializeComponent();

            

            //var assembly = typeof(AppShell);

            //= ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
        }

        private void RequestList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            RequestList.SelectedItem = null;

        }
    }
}