using ChargEVCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChargEVCompanionApp.Views.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditQuestionsPage : ContentPage
    {
        Questions SelectedQuestion;
        public EditQuestionsPage(Questions selectedQuestion)
        {
            InitializeComponent();

            this.SelectedQuestion = selectedQuestion;

            QuestionEntry.Text = selectedQuestion.Question;
            AnswerEntry.Text = selectedQuestion.Answer;
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            SelectedQuestion.Question = QuestionEntry.Text;
            SelectedQuestion.Answer = AnswerEntry.Text;

            await App.MobileService.GetTable<Questions>().UpdateAsync(SelectedQuestion);
            await DisplayAlert("Success", "News added", "Ok");
            await Navigation.PopModalAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            await App.MobileService.GetTable<Questions>().DeleteAsync(SelectedQuestion);
            await DisplayAlert("Success", "News deleted", "Ok");
            await Navigation.PopModalAsync();
        }
    }
}