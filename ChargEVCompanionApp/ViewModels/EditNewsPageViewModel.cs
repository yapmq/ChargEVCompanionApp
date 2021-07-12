using ChargEVCompanionApp.Services;
using ChargEVCompanionApp.Views.UserPages;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels
{
    class EditNewsPageViewModel : ViewModelBase
    {
        public AsyncCommand UpdateCommand { get; }
        public AsyncCommand DeleteCommand { get; }
        public EditNewsPageViewModel()
        {
            Title = "Edit News";
            UpdateCommand = new AsyncCommand(Update);
            DeleteCommand = new AsyncCommand(Delete);
        }

        private string newsTitle, newsContext;
        public string NewsContext { get => newsContext; set => SetProperty(ref newsContext, value); }
        public string NewsTitle { get => newsTitle; set => SetProperty(ref newsTitle, value); }




        async Task Update()
        {
            if (string.IsNullOrEmpty(newsContext) || (string.IsNullOrEmpty(newsTitle)))
            {
                await Shell.Current.DisplayAlert("Error", "Fields are empty!", "ok");
                return;
            }
            else
            {
                await NewsService.UpdateNews(newsTitle, newsContext);

                await Shell.Current.DisplayAlert("Success", "Data updated", "ok");

                //var route = nameof(NewsPage);
                await Shell.Current.GoToAsync("..");
            }
        }

        async Task Delete()
        {
            await NewsService.UpdateNews(newsTitle, newsContext);

            await Shell.Current.DisplayAlert("Success", "Data updated", "ok");

            //var route = nameof(NewsPage);
            await Shell.Current.GoToAsync("..");
        }
    }
}