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
    public partial class EditNewsPage : ContentPage
    {
        News selectedNews;
        public EditNewsPage(News selectedNews)
        {
            InitializeComponent();

            this.selectedNews = selectedNews;

            TitleEntry.Text = selectedNews.Title;
            ContextEntry.Text = selectedNews.Context;

        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedNews.Title = TitleEntry.Text;
            selectedNews.Context = ContextEntry.Text;

            await App.MobileService.GetTable<News>().UpdateAsync(selectedNews);
            await DisplayAlert("Success", "News added", "Ok");
            await Navigation.PopModalAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            await App.MobileService.GetTable<News>().DeleteAsync(selectedNews);
            await DisplayAlert("Success", "News deleted", "Ok");
            await Navigation.PopModalAsync();
        }
    }
}