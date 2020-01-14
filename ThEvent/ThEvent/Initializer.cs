using System;
using System.Collections.Generic;
using System.Text;
using ThEvent.Models;
using ThEvent.Data;

namespace ThEvent
{
    public class Initializer
    {
        public void Init()
        {
            App.Database.ClearTables();  //for debbug

            var eventList = App.Database.GetEventsAsync().Result;
            if (eventList.Count == 0)
            {
                Event newEv = new Event()
                {
                    Title = "Event 1",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2010, 8, 18, 19, 0, 0),
                    CreatorId = 1
                };
                App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Event 2",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2019, 4, 20, 16, 0, 0),
                    CreatorId = 1
                };
                App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Event 3",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2020, 2, 1, 10, 0, 0),
                    CreatorId = 1
                };
                App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Event 4",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2019, 10, 20, 17, 0, 0),
                    CreatorId = 1
                };
                App.Database.SaveEventAsync(newEv);
            }

            var userList = App.Database.GetUsersAsync().Result;
            if (userList.Count == 0)
            {
                User newUs = new User()
                {
                    FirstName = "q",
                    SecondName = "w",
                    Email = "q@gmail.com",
                    Password = "qw",
                    Age = 20,
                    Sex = "male",
                    Info = "there you can see your info"
                };
                App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "a",
                    SecondName = "s",
                    Email = "a@gmail.com",
                    Password = "as",
                    Age = 20,
                    Sex = "male",
                    Info = "there you can see your info"
                };
                App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "z",
                    SecondName = "x",
                    Email = "z@gmail.com",
                    Password = "zx",
                    Age = 20,
                    Sex = "female",
                    Info = "there you can see your info"
                };
                App.Database.SaveUserAsync(newUs);
            }
        }
    }
}
