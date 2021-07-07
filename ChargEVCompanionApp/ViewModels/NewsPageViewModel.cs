using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Views.AdminPages;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<News> News { get; set; }
        public NewsPageViewModel()
        {
            Title = "News and Media";
            News = new ObservableRangeCollection<News>();
            AddCommand = new AsyncCommand(Add);

        }

        public AsyncCommand AddCommand { get; }

        async Task Add()
        {
            var route = nameof(AddNewsPage);
            await Shell.Current.GoToAsync(route);
        }
    }
}
