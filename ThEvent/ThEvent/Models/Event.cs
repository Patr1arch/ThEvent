using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;


namespace ThEvent.Models
{
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullDescription { get; set; }
        public string Image { get; set; }

        [ForeignKey(typeof(User))]
        public int CreatorId { get; set; }
    }
}
