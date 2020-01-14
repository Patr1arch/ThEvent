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
            App.Database.ClearTables();

            var eventList = App.Database.GetEventsAsync().Result;
            if (eventList.Count == 0)
            {
                Event newEv = new Event()
                {
                    Title = "Event 1",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    FullDescription = "Here you can see full description of event",
                    CreatorId = 1
                };
                App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Event 2",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    FullDescription = "Here you can see full description of event",
                    CreatorId = 1
                };
                App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Event 3",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    FullDescription = "Here you can see full description of event",
                    CreatorId = 1
                };
                App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Event 4",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    FullDescription = "Here you can see full description of event",
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
                    Password = "qw"
                };
                App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "a",
                    SecondName = "s",
                    Email = "a@gmail.com",
                    Password = "as"
                };
                App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "z",
                    SecondName = "x",
                    Email = "z@gmail.com",
                    Password = "zx"
                };
                App.Database.SaveUserAsync(newUs);
            }
        }
    }
}
