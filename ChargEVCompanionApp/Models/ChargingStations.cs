using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChargEVCompanionApp.Models
{
    [Table("ChargingStations")]
    public class ChargingStations
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public string Id { get; set; }

        [Column("venueName")]
        public string VenueName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longtitude")]
        public double Longtitude { get; set; }

        [Column("stationName")]
        public string StationName { get; set; }

        [Column("stationType")]
        public string StationType { get; set; }

        [Column("code")]
        [MaxLength(4)]
        public int Code { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}
