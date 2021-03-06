﻿// IsLesserOrEqualThanConverter.cs
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
    public class IsLesserOrEqualThanConverter : IValueConverter, IMarkupExtension
    {
        public double MaxValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string valueStr && (string.IsNullOrEmpty(valueStr) == true))
            {
                return 0d <= MaxValue;
            }

            return double.Parse(value.ToString()) <= MaxValue;
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
