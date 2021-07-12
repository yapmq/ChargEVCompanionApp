using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using MvvmHelpers.Commands;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace ChargEVCompanionApp.ViewModels
{
    public class AddStationViewModel : ViewModelBase
    {

        private Venue venue;

        public Venue Venue { get => venue; set => SetProperty(ref venue, value); }
        

        public List<Venue> searchResults = new List<Venue>();
        public List<Venue> SearchResults
        {
            get
            {
                return searchResults;
            }
            set
            {
                searchResults = value;
                OnPropertyChanged();
            }
        }

        public ICommand PerformSearch => new Xamarin.Forms.Command<string>(async (string query) =>
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            SearchResults = await VenueService.GetVenues(position.Latitude, position.Longitude, query);
        });

        public AddStationViewModel()
        {
            SearchResults = new List<Venue>();
            RefreshCommand = new AsyncCommand(Refresh);

            Initialize();
        }

        public async void Initialize()
        {
            await Refresh();
        }

        public AsyncCommand RefreshCommand { get; }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            var updLocator = CrossGeolocator.Current;
            var updPosition = await updLocator.GetPositionAsync();
            SearchResults = await VenueService.GetVenues(updPosition.Latitude, updPosition.Longitude, "");
            IsBusy = false;
        }

    }
}