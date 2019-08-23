// EmptyStringToZeroConverter.cs
//
// Author: Saimel Saez <saimelsaez@gmail.com>
//
// 8/22/2019
//
// --------------------------------------------------

using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.XamarinForms.Converters
{
    public class EmptyStringToZeroConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }

            if (int.TryParse(value.ToString(), out int result) == true)
            {
                return result;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value as string) == true)
            {
                return "0";
            }

            return value.ToString();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
