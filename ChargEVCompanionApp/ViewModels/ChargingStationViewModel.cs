using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargEVCompanionApp.ViewModels
{
    public class ChargingStationViewModel : ViewModelBase
    {
        public ObservableRangeCollection<ChargingStations> Station { get; set; }
        public ObservableRangeCollection<Grouping<string, ChargingStations>> StationGroups { get; }

        public AsyncCommand RefreshCommand { get; }

        public ChargingStationViewModel()
        {

            Title = "Station List";

            Station = new ObservableRangeCollection<ChargingStations>();
            StationGroups = new ObservableRangeCollection<Grouping<string, ChargingStations>>();


            Initialize();

            RefreshCommand = new AsyncCommand(Refresh);
            
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Station.Clear();
            Load();

            IsBusy = false;
        }

        async void Initialize()
        {
            await Refresh();
        }

        async void Load()
        {
            var stations = await StationService.GetStations();
            Station.AddRange(stations);

            StationGroups.Clear();

            var venueNames = (from p in Station
                             select p.VenueName).Distinct().ToList();

            foreach (var venue in venueNames)
            {
                StationGroups.Add(new Grouping<string, ChargingStations>(venue, Station.Where(c => c.VenueName == venue)));
            }
        }
    }
}
