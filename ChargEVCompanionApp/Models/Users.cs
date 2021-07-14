using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChargEVCompanionApp.Models
{
    [Table("Users")]
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public string Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }
    }
}
