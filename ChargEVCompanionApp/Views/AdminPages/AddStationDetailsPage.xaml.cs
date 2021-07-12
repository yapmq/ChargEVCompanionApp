using ChargEVCompanionApp.Models;
using SQLite;
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
    public partial class AddStationDetailsPage : ContentPage
    {
        Venue selectedVenue;
        public AddStationDetailsPage(Venue SelectedVenue)
        {
            InitializeComponent();

            this.selectedVenue = SelectedVenue;
            venueEntry.Text = selectedVenue.name;
            addressEntry.Text = selectedVenue.location.address;
            latitudeEntry.Text = selectedVenue.location.lat.ToString();
            longtitudeEntry.Text = selectedVenue.location.lng.ToString();

        }

        private void activeButton_Clicked(object sender, EventArgs e)
        {
            double latitude = double.Parse(latitudeEntry.Text);
            double longtitude = double.Parse(longtitudeEntry.Text);
            int code = int.Parse(codeEntry.Text);
            ChargingStations station = new ChargingStations()
            {
                VenueName = venueEntry.Text,
                Address = addressEntry.Text,
                Latitude = latitude,
                Longtitude = longtitude,
                StationName = stationNameEntry.Text,
                StationType = StationTypePicker.SelectedItem.ToString(),
                Code = code,
                IsActive = true
            };

            //using (SQLiteConnection conn = new SQLiteConnection(App.))
            //{
            //    conn.CreateTable<ChargingStations>();
            //    int rows = conn.Update(station);

            //    if (rows > 0)
            //    {
            //        DisplayAlert("Success", "Data updated", "Ok");
            //    }
            //    else
            //    {
            //        DisplayAlert("Failed", "Error occured", "OK");
            //    }
            //}
        }

        private async void cancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}