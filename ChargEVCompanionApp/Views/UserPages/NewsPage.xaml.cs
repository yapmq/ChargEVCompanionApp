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
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedNews = NewsList.SelectedItem as News;

            if (selectedNews != null)
            {
                await Shell.Current.DisplayAlert(selectedNews.Title, selectedNews.Context, "OK");
            }

            NewsList.SelectedItem = null;
        }
    }
}