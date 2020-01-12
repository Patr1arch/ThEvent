using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThEvent.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
    }
}
