using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ThEvent.Models
{
    public class EventTags
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Event))]
        public int EventId { get; set; }

        [ForeignKey(typeof(Tag))]
        public int TagId { get; set; }
    }
}
