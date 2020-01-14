using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions;

namespace ThEvent.Models
{
    class Tag
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
