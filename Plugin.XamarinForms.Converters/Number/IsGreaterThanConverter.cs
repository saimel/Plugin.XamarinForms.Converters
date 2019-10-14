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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double pValue = double.Parse(parameter.ToString(), NumberStyles.Number);

            if (value is string && string.IsNullOrEmpty((string)value) == true)
            {
                return 0d > pValue;
            }

            return double.Parse(value.ToString()) > pValue;
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
