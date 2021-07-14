using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ChargEVCompanionApp.ViewModels.Converter
{
    public class IsActiveConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isactive = (bool)value;

            if (isactive == true)
            {
                return "Active";
            }
            else
            {
                return "InActive";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value;
        }
    }
}
