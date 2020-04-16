// ByteArrayToImageConverter.cs
//
// Author: Saimel Saez saimelsaez@gmail.com
//
// 3/19/2020
//
// --------------------------------------------------
using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.XamarinForms.Converters
{
    public class ByteArrayToImageConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bytes = (byte[])value;

            return ImageSource.FromStream(() => new MemoryStream(bytes));
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
