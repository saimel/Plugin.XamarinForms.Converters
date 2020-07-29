using System;
using System.Globalization;
using Xamarin.Forms;

namespace Plugin.XamarinForms.Converters
{
    public class IsNonNullOrWhitespaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string text && !string.IsNullOrWhiteSpace(text);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}