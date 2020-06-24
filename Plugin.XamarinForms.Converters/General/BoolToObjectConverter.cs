// BoolToObjectConverter.cs
//
// Author: Saimel Saez <saimelsaez@gmail.com>
//
// 5/27/2020
//
// --------------------------------------------------

using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.XamarinForms.Converters
{
    public class BoolToObjectConverter : IValueConverter, IMarkupExtension
    {
        public object IfTrue { get; set; }

        public object IfFalse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? IfTrue : IfFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, IfTrue);
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
