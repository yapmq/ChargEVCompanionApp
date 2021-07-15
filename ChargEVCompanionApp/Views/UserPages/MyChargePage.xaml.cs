using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChargEVCompanionApp.Views.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyChargePage : ContentPage
    {
        public MyChargePage()
        {
            InitializeComponent();

            GetStation();
        }


        private async void UnplugBUtton_Clicked(object sender, EventArgs e)
        {
            ChargeLog log = await StationService.IsChargerActive();

            log.IsUsing = false;
            log.TimeEnd = DateTimeOffset.Now;
            await App.MobileService.GetTable<ChargeLog>().UpdateAsync(log);

            string id = log.StationId;
            ChargingStations usedStation = await StationService.GetInUseStation(id);
            usedStation.IsActive = true;
            await App.MobileService.GetTable<ChargeLog>().UpdateAsync(log);

            await Shell.Current.DisplayAlert("Success!", "The charger has been unplugged.", "OK");
        }

        public async void GetStation()
        {
            await TestStation();
        }

        async Task TestStation()
        {
            ChargeLog test = await StationService.IsChargerActive();



            if (test == null)
            {
                StationLabel.Text = "No Current active charger in use";
                timeLabel.IsVisible = false;
                timelabel0.IsVisible = false;
                UnplugBUtton.IsVisible = false;
            }
            else
            {
                string chargeid = test.StationId;
                ChargingStations usedStation = await StationService.GetInUseStation(chargeid);


                string venue = usedStation.VenueName.ToString();
                string stationname = usedStation.StationName.ToString();
                StationLabel.Text = $"{stationname}, {venue}";

                var difference = DateTimeOffset.Now - test.TimeActive;
                string timecharged = difference.ToString(@"mm");
                timeLabel.Text = $"{timecharged} minutes";
                UnplugBUtton.IsEnabled = true;
            }
        }
    }
}