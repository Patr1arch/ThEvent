using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThEvent.Models
{
    public class UserEvents
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Event))]
        public int EventId { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
    }
}
