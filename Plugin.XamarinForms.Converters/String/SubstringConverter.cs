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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int length = 50;
            if (string.IsNullOrEmpty((string)parameter) == false)
            {
                length = int.Parse((string)parameter);
            }

            var input = (string)value;
            if (input.Length <= length)
            {
                return input;
            }

            return string.Format("{0}...", input.Substring(0, length));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
