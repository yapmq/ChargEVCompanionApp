using ChargEVCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChargEVCompanionApp.Services
{
    class StationService
    {
        public static async Task<IEnumerable<ChargingStations>> GetStations()
        {
            var stations = await App.MobileService.GetTable<ChargingStations>().ToListAsync();

            return stations;
        }
    }
}
