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
    public partial class AdminNewsPage : ContentPage
    {
        public AdminNewsPage()
        {
            InitializeComponent();
        }

        private void NewsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedNews = NewsList.SelectedItem as News;

            if (selectedNews != null)
            {
                Navigation.PushModalAsync(new EditNewsPage(selectedNews));
            }

            NewsList.SelectedItem = null;
        }
    }
}