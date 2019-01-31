using System;
using System.Globalization;
using Xamarin.Forms;

namespace Leadscore.Converters
{
    public class EmptyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;
            return string.IsNullOrWhiteSpace(str) ? "N/A" : str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException($"{nameof(EmptyStringConverter)} is one-way");
    }
}