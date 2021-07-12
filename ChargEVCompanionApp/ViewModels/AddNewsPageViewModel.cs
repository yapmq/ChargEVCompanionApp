using ChargEVCompanionApp.Services;
using ChargEVCompanionApp.Views.UserPages;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels
{
    public class AddNewsPageViewModel : ViewModelBase
    {
        public AsyncCommand SaveCommand { get; }
        public AddNewsPageViewModel()
        {
            Title = "Add News Page";
            SaveCommand = new AsyncCommand(Save);
        }

        private string newsTitle, newsContext;
        public string NewsContext { get => newsContext; set => SetProperty(ref newsContext, value); }
        public string NewsTitle { get => newsTitle; set => SetProperty(ref newsTitle, value); }




        async Task Save()
        {
            if (string.IsNullOrEmpty(newsContext) || (string.IsNullOrEmpty(newsTitle)))
            {
                await Shell.Current.DisplayAlert("Success", "Fields are empty!", "ok");
                return;
            }
            else
            {
                await NewsService.AddNews(newsTitle, newsContext);

                await Shell.Current.DisplayAlert("Success", "data added", "ok");

                var route = nameof(NewsPage);
                await Shell.Current.GoToAsync(route);
            }
        }

    }
}
