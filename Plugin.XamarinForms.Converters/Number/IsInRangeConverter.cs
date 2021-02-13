// IsInRangeConverter.cs
//
// Author: Saimel Saez <saimelsaez@gmail.com>
//
// 2/11/2021
//
// --------------------------------------------------

using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.XamarinForms.Converters
{
    public class IsInRangeConverter : IValueConverter, IMarkupExtension
    {
        public double MinValue { get; set; }

        public double MaxValue { get; set; }

        public IncludeEdges Edges { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dValue = (double)value;

            switch (Edges)
            {
                case IncludeEdges.Both:
                    return MinValue <= dValue && dValue <= MaxValue;
                case IncludeEdges.Left:
                    return MinValue <= dValue && dValue < MaxValue;
                case IncludeEdges.Right:
                    return MinValue < dValue && dValue <= MaxValue;
                default:
                    return MinValue < dValue && dValue < MaxValue;
            }
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

    public enum IncludeEdges
    {
        Both,
        Left,
        Right,
        None
    }
}
