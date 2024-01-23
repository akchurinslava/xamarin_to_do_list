using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xamarin_to_do_list.Models;

namespace xamarin_to_do_list
{
    public class to_do_repository : IDisposable
    {
        SQLiteConnection database;

        public to_do_repository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<to_do>();
        }

        public IEnumerable<to_do> GetItems()
        {
            return database.Table<to_do>().ToList();
        }

        public to_do GetItem(int id)
        {
            return database.Get<to_do>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<to_do>(id);
        }

        public int SaveItem(to_do obj)
        {
            return obj.Id != 0 ? database.Update(obj) : database.Insert(obj);
        }

        public void Dispose()
        {
            database?.Close();
        }

    }
}