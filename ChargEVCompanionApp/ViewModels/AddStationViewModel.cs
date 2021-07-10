using ChargEVCompanionApp.Models;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels
{
    public class AddStationViewModel : ViewModelBase
    {

        private Venue venue;

        public Venue Venue { get => venue; set => SetProperty(ref venue, value); }

        //private Command refreshCommand;

        //public ICommand RefreshCommand
        //{
        //    get
        //    {
        //        if (refreshCommand == null)
        //        {
        //            refreshCommand = new Command(Refresh);
        //        }

        //        return refreshCommand;
        //    }
        //}

        //private async void Refresh()
        //{
        //    venueListView.ItemsSource = null;

        //    var updLocator = CrossGeolocator.Current;
        //    var updPosition = await updLocator.GetPositionAsync();
        //    var updVenues = await VenueService.GetVenues(updPosition.Latitude, updPosition.Longitude);

        //    venueListView.ItemsSource = updVenues.Where(x => x.categories.Count() > 0).Where(x => x.location.address != null);
        //    venueListView.IsRefreshing = false;
        //}

        //private bool isRefreshing;

        //public bool IsRefreshing { get => isRefreshing; set => SetProperty(ref isRefreshing, value); }
    }
}
