// IsNonPositiveConverter.cs
//
// Author: Saimel Saez <saimelsaez@gmail.com>
//
// 8/12/2019
//
// --------------------------------------------------

using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.XamarinForms.Converters
{
    public class IsNonPositiveConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string && string.IsNullOrEmpty((string)value) == true)
            {
                return true;
            }

            return double.Parse(value.ToString()) <= 0.0;
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
