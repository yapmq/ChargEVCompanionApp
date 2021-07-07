using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChargEVCompanionApp.ViewModels
{
    class NewsPageViewModel : ViewModelBase
    {
        private string newsTitle;

        public string NewsTitle { get => newsTitle; set => SetProperty(ref newsTitle, value); }

        private string newsContext;

        public string NewsContext { get => newsContext; set => SetProperty(ref newsContext, value); }

    }
}
