using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ThEvent.Models;

namespace ThEvent.Data
{
    public class ThEventDatabase
    {
        public readonly SQLiteAsyncConnection _database;
        public ThEventDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Event>().Wait();
            _database.CreateTableAsync<Tag>().Wait();
            _database.CreateTableAsync<EventTags>().Wait();
            _database.CreateTableAsync<UserEvents>().Wait();
        }
        public void ClearTables()
        {
            _database.DeleteAllAsync<Event>().Wait();
            _database.DeleteAllAsync<User>().Wait();
            _database.DeleteAllAsync<Tag>().Wait();
            _database.DeleteAllAsync<EventTags>().Wait();
            _database.DeleteAllAsync<UserEvents>().Wait();
        }
        public void CreateTables()
        {
            _database.CreateTableAsync<Event>().Wait();
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Tag>().Wait();
            _database.CreateTableAsync<EventTags>().Wait();
            _database.CreateTableAsync<UserEvents>().Wait();
        }
        public void DropTables()
        {
            _database.DropTableAsync<User>().Wait();
            _database.DropTableAsync<Event>().Wait();
            _database.DropTableAsync<Tag>().Wait();
            _database.DropTableAsync<EventTags>().Wait();
            _database.DropTableAsync<UserEvents>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        /*public Task<List<Event>> GetEventsAsync()
        {
            return _database.Table<Event>().ToListAsync();
        }*/
        public List<Event> GetEventsAsync()
        {
            List<Event> events = _database.Table<Event>().ToListAsync().Result;
            foreach (var ev in events)
            {
                var tagsId = _database.Table<EventTags>().Where(et => et.EventId == ev.Id).ToListAsync().Result;
                foreach (var id in tagsId)
                {
                    var e = _database.Table<Tag>().FirstOrDefaultAsync(t => t.Id == id.TagId).Result;
                    if (e != null)
                        ev.EventTags.Add(e);
                }
            }
            return events;
        }
        public Task<int> SaveEventAsync(Event newEv)
        {
            return _database.InsertAsync(newEv);
        }

        public Task<List<Tag>> GetTagsAsync()
        {
            return _database.Table<Tag>().ToListAsync();
        }
        public Task<int> SaveTagAsync(Tag newTag)
        {
            return _database.InsertAsync(newTag);
        }
        public Task<List<EventTags>> GetEventTagsAsync()
        {
            return _database.Table<EventTags>().ToListAsync();
        }
        public Task<int> SaveEventTagAsync(EventTags newET)
        {
            return _database.InsertAsync(newET);
        }
        public Task<List<UserEvents>> GetUserEventsAsync()
        {
            return _database.Table<UserEvents>().ToListAsync();
        }
        public Task<int> SaveEventTagAsync(UserEvents newUE)
        {
            return _database.InsertAsync(newUE);
        }
    }
}
