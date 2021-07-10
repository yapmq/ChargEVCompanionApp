using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChargEVCompanionApp.Views.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStationPage : ContentPage
    {
        public AddStationPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status == PermissionStatus.Denied)
                {
                    if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
                    {
                        await DisplayAlert("Need your location", "We need to access your location", "OK");
                    }

                    PermissionStatus result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if (result == PermissionStatus.Granted)
                    {
                        status = result;
                    }
                }

                if (status == PermissionStatus.Granted)
                {
                    var locator = CrossGeolocator.Current;
                    var position = await locator.GetPositionAsync();

                    var venues = await VenueService.GetVenues(position.Latitude, position.Longitude);
                    venueListView.ItemsSource = venues.Where(x => x.categories.Count() > 0).Where(x => x.location.address != null);
                    //venueListView.ItemsSource = venues;
                }
                else
                {
                    await DisplayAlert("Location denied", "We need your permission to access your location, else you cannot show your location on map", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

            venueListView.RefreshCommand = new Command(async () =>
            {
                venueListView.ItemsSource = null;

                var updLocator = CrossGeolocator.Current;
                var updPosition = await updLocator.GetPositionAsync();
                var updVenues = await VenueService.GetVenues(updPosition.Latitude, updPosition.Longitude);

                venueListView.ItemsSource = updVenues.Where(x => x.categories.Count() > 0).Where(x => x.location.address != null);
                venueListView.IsRefreshing = false;
            });
        }
    }
}