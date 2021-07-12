using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            //GetPermissions();

        }

        private void venueListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedVenue = venueListView.SelectedItem as Venue;

            if (selectedVenue != null)
            {
                Navigation.PushModalAsync(new AddStationDetailsPage(selectedVenue));
            }

        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    try
        //    {
        //        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        //        if (status == PermissionStatus.Denied)
        //        {
        //            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
        //            {
        //                await DisplayAlert("Need your location", "We need to access your location", "OK");
        //            }

        //            PermissionStatus result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        //            if (result == PermissionStatus.Granted)
        //            {
        //                status = result;
        //            }
        //        }

        //        if (status == PermissionStatus.Granted)
        //        {
        //            var locator = CrossGeolocator.Current;
        //            var position = await locator.GetPositionAsync();

        //            var venues = await VenueService.GetVenues(position.Latitude, position.Longitude);
        //            venueListView.ItemsSource = venues.Where(x => x.categories.Count() > 0).Where(x => x.location.address != null);

        //            //if (string.IsNullOrWhiteSpace(LocationSearch.Text))
        //            //    venueListView.ItemsSource = venues.Where(x => x.categories.Count() > 0).Where(x => x.location.address != null);
        //            //else
        //            //    venueListView.ItemsSource = venues.Where(x => x.categories.Count() > 0).Where(x => x.location.address != null).Where(x => x.name.Contains(LocationSearch.Text));
        //            //venueListView.ItemsSource = venues;
        //        }
        //        else
        //        {
        //            await DisplayAlert("Location denied", "We need your permission to access your location, else you cannot show your location on map", "OK");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", ex.Message, "Ok");
        //    }
        //    //venueListView.RefreshCommand = new Command(async () =>
        //    //{

        //    //});
        //}

        //private async void GetPermissions()
        //{
        //    try
        //    {
        //        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        //        if (status == PermissionStatus.Denied)
        //        {
        //            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
        //            {
        //                await DisplayAlert("Need your location", "We need to access your location", "OK");
        //            }

        //            PermissionStatus result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        //            if (result == PermissionStatus.Granted)
        //            {
        //                status = result;
        //            }
        //        }

        //        if (status == PermissionStatus.Granted)
        //        {
        //            var locator = CrossGeolocator.Current;
        //            var position = await locator.GetPositionAsync();

        //            var venues = await VenueService.GetVenues(position.Latitude, position.Longitude);
        //            venueListView.ItemsSource = venues.Where(x => x.categories.Count() > 0).Where(x => x.location.address != null);
        //        }
        //        else
        //        {
        //            await DisplayAlert("Location denied", "We need your permission to access your location, else you cannot show your location on map", "OK");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", ex.Message, "Ok");
        //    }
        //}

        //private async void LocationSearch_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var updLocator = CrossGeolocator.Current;
        //    var updPosition = await updLocator.GetPositionAsync();
        //    var updVenues = await VenueService.GetVenues(updPosition.Latitude, updPosition.Longitude);
        //    venueListView.BeginRefresh();


        //    if (string.IsNullOrWhiteSpace(e.NewTextValue))
        //    {
        //        venueListView.ItemsSource = updVenues.Where(x => x.categories.Count() > 0).Where(x => x.location.address != null);
        //    }
        //    else
        //    {
        //        venueListView.ItemsSource = updVenues.Where(x => x.name.Contains(e.NewTextValue));
        //    }//Where(x => x.categories.Count() > 0).Where(x => x.location.address != null).

        //    venueListView.EndRefresh();
        //}

        //private async void venueListView_Refreshing(object sender, EventArgs e)
        //{
        //    venueListView.ItemsSource = null;

        //    var updLocator = CrossGeolocator.Current;
        //    var updPosition = await updLocator.GetPositionAsync();
        //    var updVenues = await VenueService.GetVenues(updPosition.Latitude, updPosition.Longitude);

        //    venueListView.ItemsSource = updVenues.Where(x => x.categories.Count() > 0).Where(x => x.location.address != null);
        //    venueListView.IsRefreshing = false;
        //}
    }
}