// SubstringConverter.cs
//
// Author: Saimel Saez <saimelsaez@gmail.com>
//
// 8/13/2019
//
// --------------------------------------------------


using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.XamarinForms.Converters
{
    public class SubstringConverter : IValueConverter, IMarkupExtension
    {
        public int MaxLength { get; set; } = 50;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var input = (string)value;
            if (input.Length <= MaxLength)
            {
                return input;
            }

            return string.Format("{0}...", input.Substring(0, MaxLength));
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
