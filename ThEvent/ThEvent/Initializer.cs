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
            //App.Database.ClearTables();  //for debbug
            App.Database.DropTables();
            App.Database.CreateTables();

            var eventList = App.Database.GetEventsAsync();
            if (eventList.Count == 0)
            {
                Event newEv = new Event()
                {
                    Title = "Event 1",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2010, 8, 18, 19, 0, 0),
                    Address = "address",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Event 2",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2019, 4, 20, 16, 0, 0),
                    Address = "address",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Event 3",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2020, 2, 1, 10, 0, 0),
                    Address = "address",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Event 4",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2019, 10, 20, 17, 0, 0),
                    Address = "address",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
            }

            var userList = App.Database.GetUsersAsync().Result;
            if (userList.Count == 0)
            {
                User newUs = new User()
                {
                    FirstName = "Admin",
                    SecondName = "",
                    Email = "admin@gmail.com",
                    Password = "123",
                    Age = 20,
                    Sex = "male",
                    Info = "I'm admin!",
                    Image = "https://whatsism.com/uploads/posts/2019-07/1563281010_83b1f339-d4cb-46d4-82d8-8a0ee692f3e0.jpeg",
                    IsAdmin = true
                };
                _ = App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "a",
                    SecondName = "s",
                    Email = "a@gmail.com",
                    Password = "as",
                    Age = 20,
                    Sex = "male",
                    Info = "there you can see your info",
                    Image = "https://avatars.mds.yandex.net/get-pdb/1945878/adbb29db-f37d-4647-a535-ff6448bd9c50/s1200",
                    IsAdmin = false
                };
                _ = App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "z",
                    SecondName = "x",
                    Email = "z@gmail.com",
                    Password = "zx",
                    Age = 20,
                    Sex = "female",
                    Info = "there you can see your info",
                    Image = "https://avatars.mds.yandex.net/get-pdb/1751508/9b0e0e48-4ac0-4423-a971-e612788cf3bc/s1200",
                    IsAdmin = false
                };
                _ = App.Database.SaveUserAsync(newUs);
            }

            var tagList = App.Database.GetTagsAsync().Result;
            if (tagList.Count == 0)
            {
                Tag newTag = new Tag()
                {
                    Title = "tag 1"
                };
                _ = App.Database.SaveTagAsync(newTag);
                newTag = new Tag()
                {
                    Title = "tag 2"
                };
                _ = App.Database.SaveTagAsync(newTag);
                newTag = new Tag()
                {
                    Title = "tag 3"
                };
                _ = App.Database.SaveTagAsync(newTag);
                newTag = new Tag()
                {
                    Title = "tag 4"
                };
                _ = App.Database.SaveTagAsync(newTag);
            }


            var eventTagsList = App.Database.GetEventTagsAsync().Result;
            if (eventTagsList.Count == 0)
            {
                EventTags newET = new EventTags()
                {
                    EventId = 1,
                    TagId = 2
                };
                App.Database.SaveEventTagAsync(newET);
                newET = new EventTags()
                {
                    EventId = 2,
                    TagId = 1
                };
                App.Database.SaveEventTagAsync(newET);
                newET = new EventTags()
                {
                    EventId = 2,
                    TagId = 3
                };
                App.Database.SaveEventTagAsync(newET);
            }

            var userEventsList = App.Database.GetUserEventsAsync().Result;
            if (userEventsList.Count == 0)
            {
                UserEvents newUE = new UserEvents()
                {
                    EventId = 1,
                    UserId = 2
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 1,
                    UserId = 3
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 2,
                    UserId = 3
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 3,
                    UserId = 3
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 3,
                    UserId = 2
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 4,
                    UserId = 3
                };
            }
        }
    }
}
