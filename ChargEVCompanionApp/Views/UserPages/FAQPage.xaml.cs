using ChargEVCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChargEVCompanionApp.Views.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FAQPage : ContentPage
    {
        public FAQPage()
        {
            InitializeComponent();
        }

        private async void QuestionList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedQuestion = QuestionList.SelectedItem as Questions;

            if (selectedQuestion != null)
            {
                await Shell.Current.DisplayAlert(selectedQuestion.Question, selectedQuestion.Answer, "OK");
            }

            QuestionList.SelectedItem = null;
        }
    }
}