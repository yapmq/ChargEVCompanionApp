using ChargEVCompanionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ChargEVCompanionApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}