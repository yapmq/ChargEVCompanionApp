using ChargEVCompanionApp.Views.UserPages;
using Xamarin.Forms;

namespace ChargEVCompanionApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new MapPage();
        }

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
