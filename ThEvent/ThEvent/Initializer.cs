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
                _ = App.Database.SaveEventAsync(newEv).Result;
                newEv = new Event()
                {
                    Title = "Event 2",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2019, 4, 20, 16, 0, 0),
                    Address = "address",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv).Result;
                newEv = new Event()
                {
                    Title = "Event 3",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2020, 2, 1, 10, 0, 0),
                    Address = "address",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv).Result;
                newEv = new Event()
                {
                    Title = "Event 4",
                    Image = "https://sun9-48.userapi.com/c200828/v200828821/352cf/NHXlNXqYXow.jpg",
                    Info = "Here you can see full description of event",
                    Date = new DateTime(2019, 10, 20, 17, 0, 0),
                    Address = "address",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv).Result;
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
                    Info = "there you can see your info",
                    Image = "https://whatsism.com/uploads/posts/2019-07/1563281010_83b1f339-d4cb-46d4-82d8-8a0ee692f3e0.jpeg"
                };
                _ = App.Database.SaveUserAsync(newUs).Result;
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
                };
                _ = App.Database.SaveUserAsync(newUs).Result;
                newUs = new User()
                {
                    FirstName = "z",
                    SecondName = "x",
                    Email = "z@gmail.com",
                    Password = "zx",
                    Age = 20,
                    Sex = "female",
                    Info = "there you can see your info",
                    Image = "https://avatars.mds.yandex.net/get-pdb/1751508/9b0e0e48-4ac0-4423-a971-e612788cf3bc/s1200"
                };
                _ = App.Database.SaveUserAsync(newUs).Result;
            }

            var tagList = App.Database.GetTagsAsync().Result;
            if (tagList.Count == 0)
            {
                Tag newTag = new Tag()
                {
                    Title = "tag 1"
                };
                _ = App.Database.SaveTagAsync(newTag).Result;
                newTag = new Tag()
                {
                    Title = "tag 2"
                };
                _ = App.Database.SaveTagAsync(newTag).Result;
                newTag = new Tag()
                {
                    Title = "tag 3"
                };
                _ = App.Database.SaveTagAsync(newTag).Result;
                newTag = new Tag()
                {
                    Title = "tag 4"
                };
                _ = App.Database.SaveTagAsync(newTag).Result;
            }


            var eventTagsList = App.Database.GetEventTagsAsync().Result;
            if (eventTagsList.Count == 0)
            {
                eventList = App.Database.GetEventsOnly().Result;
                tagList = App.Database.GetTagsAsync().Result;

                EventTags newET = new EventTags()
                {
                    EventId = eventList[0].Id,
                    TagId = tagList[1].Id
                };
                App.Database.SaveEventTagAsync(newET);
                newET = new EventTags()
                {
                    EventId = eventList[1].Id,
                    TagId = tagList[0].Id
                };
                App.Database.SaveEventTagAsync(newET);
                newET = new EventTags()
                {
                    EventId = eventList[1].Id,
                    TagId = tagList[2].Id
                };
                App.Database.SaveEventTagAsync(newET);
            }

            var userEventsList = App.Database.GetUserEventsAsync().Result;
            if (userEventsList.Count == 0)
            {
                eventList = App.Database.GetEventsOnly().Result;
                userList = App.Database.GetUsersAsync().Result;

                UserEvents newUE = new UserEvents()
                {
                    EventId = eventList[0].Id,
                    UserId = userList[0].Id
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = eventList[0].Id,
                    UserId = userList[1].Id
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = eventList[1].Id,
                    UserId = userList[0].Id
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = eventList[1].Id,
                    UserId = userList[2].Id
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = eventList[2].Id,
                    UserId = userList[0].Id
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = eventList[2].Id,
                    UserId = userList[1].Id
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = eventList[3].Id,
                    UserId = userList[2].Id
                };
            }
        }
    }
}
