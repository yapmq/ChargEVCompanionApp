using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChargEVCompanionApp.Models
{
    [Table("News")]
    public class News
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public string Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("context")]
        public string Context { get; set; }

        [Column("createdAt")]
        public DateTimeOffset createdAt { get; set; }
    }
}
