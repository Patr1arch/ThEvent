using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions;

namespace ThEvent.Models
{
    public class Tag
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
