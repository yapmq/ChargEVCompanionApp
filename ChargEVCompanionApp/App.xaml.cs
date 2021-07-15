using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Views;
using ChargEVCompanionApp.Views.AdminPages;
using ChargEVCompanionApp.Views.UserPages;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Xamarin.Forms;

namespace ChargEVCompanionApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation;
        public static MobileServiceClient MobileService = new MobileServiceClient("https://chargevcompanionapp.azurewebsites.net");

        public static Users globaluser = new Users(); //to store specific user id upon logged in
        //public App()
        //{
        //    InitializeComponent();

        //    //MainPage = new RegisterUserPage();
        //}

        public App(string databaseLocation) ////
        {
            InitializeComponent();

            MainPage = new AppShell();

            DatabaseLocation = databaseLocation;
        }

        //var store = new MobileServiceSQLiteStore(databaseLocation);
        //store.DefineTable<ChargingStations>();

        //MobileService.SyncContext.InitializeAsync(store);

        //chargingstations = MobileService.GetSyncTable<ChargingStations>();

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
