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
    public partial class ActiveChargerDetailsPage : ContentPage
    {
        ChargingStations SelectedCharger;
        public ActiveChargerDetailsPage(ChargingStations selectedCharger)
        {
            InitializeComponent();

            this.SelectedCharger = selectedCharger;

            StationNameLabel.Text = selectedCharger.StationName;
            LocationLabel.Text = selectedCharger.VenueName;
            AddressLabel.Text = selectedCharger.Address;
            bool status = selectedCharger.IsActive;
            string latitude = selectedCharger.Latitude.ToString();
            string longtitude = selectedCharger.Longtitude.ToString();
            LatitudeLabel.Text = $"Latitude: {latitude}";
            LongtitudeLabel.Text = $"Longtitidue: {longtitude}";

            if (status)
                ChargerStatus.Text = "Active";
            else
            {
                ChargerStatus.Text = "Inactive";
                ActivateButton.IsEnabled = false;
                CodeEntry.IsVisible = false;
                CancelButoon.Text = "Back";
            }

        }

        private async void ActivateButton_Clicked(object sender, EventArgs e)
        {
            if (CodeEntry.Text != null) //check if field is entered
            {
                ChargeLog log = new ChargeLog();
                log.UserId = App.globaluser.Id;
                SelectedCharger.Code = int.Parse(CodeEntry.Text);
                Memberships membership = await MembershipServices.IsMemberActive();

                var ChargerInUse = (await App.MobileService.GetTable<ChargeLog>().Where(s => s.UserId == log.UserId).Where(s => s.IsUsing == true).ToListAsync()).FirstOrDefault(); //check if user is using

                if (ChargerInUse == null)//check is any charger is active unnder user or not.
                {
                    if (membership != null) //check if pass is valid
                    {
                        var stations = (await App.MobileService.GetTable<ChargingStations>().Where(s => s.Id == SelectedCharger.Id).ToListAsync()).FirstOrDefault();
                        //get row from fetched id, and active the same time
                        if (stations.IsActive == true) //double check if station is active or not
                        {
                            if (stations.Code == SelectedCharger.Code) //validate passcode
                            {
                                //add charge log

                                log.StationId = SelectedCharger.Id;
                                log.TimeActive = DateTimeOffset.Now;
                                log.IsUsing = true;
                                await App.MobileService.GetTable<ChargeLog>().InsertAsync(log);


                                stations.IsActive = false;
                                await App.MobileService.GetTable<ChargingStations>().UpdateAsync(stations);


                                await Shell.Current.DisplayAlert("Success!", $"system: {stations.Code}, input = {SelectedCharger.Code}", "OK");
                                await Shell.Current.GoToAsync("//MapPage");
                            }
                            else
                            {
                                await Shell.Current.DisplayAlert("Failed!", "Make sure the code are correct", "OK");
                            }
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error!", "Station is currently not active.", "OK");
                        }
                    }
                    else //if pass valid, check code
                    {

                        await Shell.Current.DisplayAlert("No pass activated", "Please activate a pass before using your charger", "OK");

                        await Shell.Current.GoToAsync("//MembershipPage");
                    }
                } 
                else
                {
                    await Shell.Current.DisplayAlert("Error!", "You have one station currently active. Please stop the station from charging before continuing this operation", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "Please enter activation code", "OK");
            }
        }

        private void CancelButoon_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}