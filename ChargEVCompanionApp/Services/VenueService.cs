using ChargEVCompanionApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChargEVCompanionApp.Services
{
    class VenueService
    {
        public async static Task<List<Venue>> GetVenues(double latitude, double longtitude, string queryString)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenerateURl(latitude, longtitude);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                
                var json = await response.Content.ReadAsStringAsync(); //get values in json

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                var normalizedQuery = queryString?.ToLower() ?? "";
                if (!string.IsNullOrWhiteSpace(normalizedQuery))
                {
                    venues = venueRoot.response.venues.Where(f => f.name.ToLowerInvariant().Contains(normalizedQuery)).ToList();
                }
                else
                {
                    venues = venueRoot.response.venues.Where(x => x.categories.Count() > 0).ToList();
                }
            }

            return venues;
        }

        //get saved stations
        public static async Task<List<ChargingStations>> Read()
        {
            var posts = await App.MobileService.GetTable<ChargingStations>().ToListAsync();

            return posts;
        }
    }
}


