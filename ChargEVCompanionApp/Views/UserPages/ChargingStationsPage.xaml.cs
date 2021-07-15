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
    public partial class ChargingStationsPage : ContentPage
    {
        public ChargingStationsPage()
        {
            InitializeComponent();            
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (StationList.SelectedItem != null)
            {
                var selectedStation = StationList.SelectedItem as ChargingStations;
                Navigation.PushModalAsync(new ActiveChargerDetailsPage(selectedStation));
            }


            StationList.SelectedItem = null;
        }

        private void statusLabel_BindingContextChanged(object sender, EventArgs e)
        {
            
        }
    }
}