using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using ChargEVCompanionApp.Views.AdminPages;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels
{
    class AdminNewsPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<News> NewsList { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AdminNewsPageViewModel()
        {
            Title = "News and Media";
            NewsList = new ObservableRangeCollection<News>();
            //NewsList.Add(new News { Title = "hello world", Context = "testing123", DateCreated = DateTime.Today });

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            Initialize();
        }

        public async void Initialize()
        {
            await Refresh();
        }


        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            NewsList.Clear();
            var news = await NewsService.GetNews();
            NewsList.AddRange(news);

            IsBusy = false;
        }


        async Task Add()
        {
            var route = nameof(AddNewsPage);
            await Shell.Current.GoToAsync(route);
        }
    }
}
