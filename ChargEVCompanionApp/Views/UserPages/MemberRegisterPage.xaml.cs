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
    public partial class MemberRegisterPage : ContentPage
    {
        
        public MemberRegisterPage()
        {
            InitializeComponent();
            priceLabel.IsVisible = false;
            LabelPrice.IsVisible = false;
        }

        private void PassPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            priceLabel.IsVisible = true;
            LabelPrice.IsVisible = true;
            if (PassPicker.SelectedIndex == 0)
            {
                priceLabel.Text = "15.00";
            }
            else if(PassPicker.SelectedIndex == 1)
            {
                priceLabel.Text = "100.00";
            }
            else if (PassPicker.SelectedIndex == 2)
            {
                priceLabel.Text = "420.00";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(PassPicker.SelectedIndex != -1)
            {
                decimal price = decimal.Parse(priceLabel.Text);
                string pass = PassPicker.SelectedItem.ToString();
                Navigation.PushModalAsync(new PassPaymentPage(pass, price));
            }
            else
            {
                Shell.Current.DisplayAlert("Error", "Please choose a pass", "OK");
            }
        }
    }
}