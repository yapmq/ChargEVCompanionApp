using ChargEVCompanionApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChargEVCompanionApp.Services
{
    class NewsService
    {
        //static SQLiteAsyncConnection db;
        //static async Task Init()
        //{
        //    if (db != null)
        //        return;

        //    // Get an absolute path to the database file
        //    var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

        //    db = new SQLiteAsyncConnection(databasePath);

        //    await db.CreateTableAsync<News>();

        //}

        public static async Task AddNews(string title, string context)
        {
            var news = new News
            {
                Title = title,
                Context = context,
            };

            await App.MobileService.GetTable<News>().InsertAsync(news);

        }

        public static async Task UpdateNews(string title, string context)
        {
            var news = new News
            {
                Title = title,
                Context = context,
            };

            await App.MobileService.GetTable<News>().UpdateAsync(news);
        }

        public static async Task<IEnumerable<News>> GetNews()
        {
            //await Init();

            var news = await App.MobileService.GetTable<News>().ToListAsync();

            return news;
        }
    }
}
