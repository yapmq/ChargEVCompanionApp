using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
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
        public ObservableRangeCollection<News> NewsList { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public NewsPageViewModel()
        {
            Title = "News and Media";
            NewsList = new ObservableRangeCollection<News>();
            //NewsList.Add(new News { Title = "hello world", Context = "testing123", DateCreated = DateTime.Today });
            
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            Refresh();
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


        public AsyncCommand AddCommand { get; }

        async Task Add()
        {
            var route = nameof(AddNewsPage);
            await Shell.Current.GoToAsync(route);
        }
    }
}
