using ChargEVCompanionApp.Models;
using MvvmHelpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ChargEVCompanionApp.Services
{
    public static class DatabaseHandler
    {
        //static SQLiteAsyncConnection db;
        //public static async Task Init()
        //{
        //    if (db != null)
        //        return;

        //    // Get an absolute path to the database file
        //    var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

        //    db = new SQLiteAsyncConnection(databasePath);

        //    await db.CreateTableAsync<News>();

        //}

        //public static async Task AddNews(string title, string context)
        //{
        //    await Init();
        //    //var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
        //    var datecreated = DateTime.Now;
        //    var news = new News
        //    {
        //        Title = title,
        //        Context = context,
        //        DateCreated = datecreated
        //    };

        //    var id = await db.InsertAsync(news);
        //}

        //public static async Task RemoveCoffee(int id)
        //{

        //    await Init();

        //    await db.DeleteAsync<Coffee>(id);
        //}

        //public static async Task<IEnumerable<Coffee>> GetCoffee()
        //{
        //    await Init();

        //    var coffee = await db.Table<Coffee>().ToListAsync();
        //    return coffee;
        //}

        //public static async Task<IEnumerable<News>> GetNews()
        //{
        //    await Init();

        //    var news = await db.Table<News>().ToListAsync();

        //    return news;
        //}

        
    }
}
