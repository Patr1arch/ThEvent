﻿using System;
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
            _database.CreateTableAsync<Event>().Wait();
            _database.CreateTableAsync<User>().Wait();
        }

        public void DropTables()
        {
            _database.DropTableAsync<User>().Wait();
            _database.DropTableAsync<Event>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<Event>> GetEventsAsync()
        {
            return _database.Table<Event>().ToListAsync();
        }
        public Task<int> SaveEventAsync(Event newEv)
        {
            return _database.InsertAsync(newEv);
        }
    }
}
