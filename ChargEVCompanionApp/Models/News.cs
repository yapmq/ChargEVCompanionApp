﻿using SQLite;
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
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("context")]
        public string Context { get; set; }

        [Column("dateCreated")]
        public DateTime DateCreated { get; set; }
    }
}