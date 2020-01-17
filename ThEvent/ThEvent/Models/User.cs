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
        public string Password { get; set; }
        public string Info { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public string Image { get; set; }
        public bool IsAdmin { get; set; }

        [Ignore]
        public List<Event> UserEvents { get; set; }

        public User()
        {
            UserEvents = new List<Event>();
        }
    }
}
