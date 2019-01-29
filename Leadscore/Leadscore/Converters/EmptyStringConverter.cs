using System;
using System.Globalization;
using Xamarin.Forms;

namespace Leadscore.Converters
{
    public class EmptyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (String)value;
            return String.IsNullOrWhiteSpace(str) ? "N/A" : str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException(string.Format("{0} is one-way", nameof(EmptyStringConverter)));
    }
}