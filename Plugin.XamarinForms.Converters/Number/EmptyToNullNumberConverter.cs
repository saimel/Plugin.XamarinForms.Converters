// EmptyToNullNumberConverter.cs
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
    public class EmptyToNullNumberConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return null;
            }

            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
