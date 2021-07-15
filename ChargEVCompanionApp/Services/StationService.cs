using ChargEVCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static async Task<ChargingStations> GetInUseStation(string id)
        {
            var stations = (await App.MobileService.GetTable<ChargingStations>()
                .Where(x => x.Id == id)
                .ToListAsync()).FirstOrDefault();

            return stations;
        }

        public static async Task<ChargeLog> IsChargerActive()
        {
            ChargeLog chargelog = (await App.MobileService.GetTable<ChargeLog>()
                .Where(m => m.IsUsing == true)
                .Where(m => m.UserId == App.globaluser.Id)
                .ToListAsync()).FirstOrDefault();

            if (chargelog != null)
            {
                DateTimeOffset timeActivated = chargelog.TimeActive;
                DateTimeOffset timeNow = DateTimeOffset.Now;
                var difference = timeNow - timeActivated;

                if (difference.TotalMinutes > 1) //if active more than one hour, automatically turn off the charger
                {
                    chargelog.IsUsing = false;
                    chargelog.TimeEnd = DateTimeOffset.Now;
                    await App.MobileService.GetTable<ChargeLog>().UpdateAsync(chargelog);


                    ChargingStations charger = (await App.MobileService.GetTable<ChargingStations>()
                        .Where(m => m.Id == chargelog.StationId)
                        .ToListAsync()).FirstOrDefault();
                    charger.IsActive = true;
                    await App.MobileService.GetTable<ChargingStations>().UpdateAsync(charger);

                    ChargeLog newchargelog = (await App.MobileService.GetTable<ChargeLog>()
                    .Where(m => m.IsUsing == true)
                    .Where(m => m.UserId == App.globaluser.Id)
                    .ToListAsync()).FirstOrDefault();

                    return newchargelog;
                }
                else
                {
                    return chargelog;
                }
            }
            else
            {
                return chargelog;
            }



            //if (chargelog != null)
            //{
            //    ChargingStations charger = (await App.MobileService.GetTable<ChargingStations>()
            //    .Where(m => m.Id == chargelog.StationId)
            //    .Where(m => m. == App.globaluser.Id)
            //    .ToListAsync()).FirstOrDefault();
            //}
        }

    }
}
