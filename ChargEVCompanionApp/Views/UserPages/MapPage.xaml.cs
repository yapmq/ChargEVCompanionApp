using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChargEVCompanionApp.Views.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();

            GetPermissions();
        }

        private async void GetPermissions()
        {
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
                    hasLocationPermission = true;
                    LocationMap.IsShowingUser = true;
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
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;


                locator.PositionChanged += Locator_PositionChanged;
                if (locator != null && locator.IsListening != true)
                {
                    await locator.StartListeningAsync(TimeSpan.FromSeconds(5), 100);
                }

            }
            GetLocation();

            var stations = await VenueService.Read();
            DisplayInMap(stations);
        }

        private async void DisplayInMap(List<ChargingStations> stations)
        {
            foreach (var station in stations)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(station.Latitude, station.Longtitude);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = station.VenueName,
                        Address = station.Address
                    };

                    LocationMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre)
                {
                    await Shell.Current.DisplayAlert("Error", "Null Reference", "Ok");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", "Exception", "Ok");
                }
            }
        }


        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude); //coordinates of user
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            LocationMap.MoveToRegion(span); //move map to user's location
        }

        void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }
    }
}