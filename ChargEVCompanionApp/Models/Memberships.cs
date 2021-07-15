using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChargEVCompanionApp.Models
{
    [Table("Memberships")]
    public class Memberships
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public string Id { get; set; }

        [Column("userId")]
        public string UserId { get; set; }

        [Column("subscriptionType")]
        public string SubscriptionType { get; set; } //one day pass, 7-day pass, monthly pass

        [Column("CreatedAt")]
        public DateTimeOffset createdAt { get; set; } //start time

        [Column("endTime")]
        public DateTimeOffset EndTime { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; } //if datetimeoffset.now - datecreated > pass duration: IsActive = false
    }
}
