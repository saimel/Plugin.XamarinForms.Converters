using System;
using System.Globalization;
using Xamarin.Forms;

namespace Plugin.XamarinForms.Converters
{
    public class IsNonNullOrWhitespaceConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string text && !string.IsNullOrWhiteSpace(text);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
