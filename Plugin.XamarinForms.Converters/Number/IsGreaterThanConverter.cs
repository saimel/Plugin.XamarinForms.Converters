// IsGreaterThanConverter.cs
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
    public class IsGreaterThanConverter : IValueConverter, IMarkupExtension
    {
        public double MinValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string valueStr && (string.IsNullOrEmpty(valueStr) == true))
            {
                return 0d > MinValue;
            }

            return double.Parse(value.ToString()) > MinValue;
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
