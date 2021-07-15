using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChargEVCompanionApp.Models
{
    [Table("ChargeLog")]
    class ChargeLog
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public string Id { get; set; }

        [Column("userId")]
        public string UserId { get; set; }

        [Column("stationId")]
        public string StationId { get; set; }

        [Column("timeActive")]
        public DateTimeOffset TimeActive { get; set; }

        [Column("timeEnd")]
        public DateTimeOffset TimeEnd { get; set; }

        [Column("isUsing")]
        public bool IsUsing { get; set; }
    }
}
