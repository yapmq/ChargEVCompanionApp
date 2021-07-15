using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChargEVCompanionApp.ViewModels
{
    class FAQPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Questions> QuestionList { get; set; }
        public AsyncCommand RefreshCommand { get; }


        public FAQPageViewModel()
        {
            Title = "Frequently Asked Questions";
            QuestionList = new ObservableRangeCollection<Questions>();


            RefreshCommand = new AsyncCommand(Refresh);
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
    }
}
