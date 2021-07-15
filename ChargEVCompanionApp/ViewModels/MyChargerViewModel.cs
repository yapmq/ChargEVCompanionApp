using System;
using System.Collections.Generic;
using System.Text;

namespace ChargEVCompanionApp.ViewModels
{
    public class MyChargerViewModel : ViewModelBase
    {
        const int RefreshDuration = 2;
        readonly Random random;
        bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
    }
}
