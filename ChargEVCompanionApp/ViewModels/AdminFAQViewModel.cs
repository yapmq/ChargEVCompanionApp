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
    public class AdminFAQViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Questions> QuestionList { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AdminFAQViewModel()
        {
            Title = "Frequently Asked Questions";
            QuestionList = new ObservableRangeCollection<Questions>();

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

            QuestionList.Clear();
            var question = await QuestionService.GetQuestion();
            QuestionList.AddRange(question);

            IsBusy = false;
        }


        async Task Add()
        {
            var route = nameof(NewFAQPage);
            await Shell.Current.GoToAsync(route);
        }
    }
}
