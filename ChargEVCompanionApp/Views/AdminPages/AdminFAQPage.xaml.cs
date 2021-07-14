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
    public partial class AdminFAQPage : ContentPage
    {
        public AdminFAQPage()
        {
            InitializeComponent();
        }
        private void QuestionList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedQuestion = QuestionList.SelectedItem as Questions;

            if (selectedQuestion != null)
            {
                Navigation.PushModalAsync(new EditQuestionsPage(selectedQuestion));
            }

            QuestionList.SelectedItem = null;
        }
    }
}