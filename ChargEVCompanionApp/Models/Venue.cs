using ChargEVCompanionApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChargEVCompanionApp.Models
{
    public class Venue
    {
        public static string GenerateURl(double latitude, double longtitude)
        {
            return string.Format(Constants.VENUE_SEARCH, latitude, longtitude, Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
