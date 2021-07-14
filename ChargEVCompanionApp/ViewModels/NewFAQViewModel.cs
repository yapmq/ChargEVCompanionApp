using ChargEVCompanionApp.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels
{
    class NewFAQViewModel : ViewModelBase
    {
        public AsyncCommand SaveCommand { get; }

        private string question;
        public string Question { get => question; set => SetProperty(ref question, value); }

        private string answer;
        public string Answer { get => answer; set => SetProperty(ref answer, value); }

        public NewFAQViewModel()
        {
            Title = "Add New FAQ Page";
            SaveCommand = new AsyncCommand(Save);
        }

        async Task Save()
        {
            if (string.IsNullOrEmpty(question) || (string.IsNullOrEmpty(answer)))
            {
                await Shell.Current.DisplayAlert("Error", "Fields are empty!", "ok");
                return;
            }
            else
            {
                await QuestionService.AddQuestion(question, answer);

                await Shell.Current.DisplayAlert("Success", "data added", "ok");

                await Shell.Current.GoToAsync("..");
            }
        }

    }
}
