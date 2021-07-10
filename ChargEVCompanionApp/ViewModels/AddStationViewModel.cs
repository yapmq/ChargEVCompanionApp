using ChargEVCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChargEVCompanionApp.ViewModels
{
    public class AddStationViewModel : ViewModelBase
    {

        private Venue venue;

        public Venue Venue { get => venue; set => SetProperty(ref venue, value); }

    }
}
