using ChargEVCompanionApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChargEVCompanionApp.Services
{
    class VenueService
    {
        public async static Task<List<Venue>> GetVenues(double latitude, double longtitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenerateURl(latitude, longtitude);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync(); //get values in json

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);
                venues = venueRoot.response.venues as List<Venue>;
            }

            return venues;


        }
    }
}
