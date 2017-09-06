using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Converter to convert between int and GridLength
    /// </summary>
    [ValueConversion(typeof(Double), typeof(GridLength))]
    public class IntToGridLengthConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            // check whether a value is given
            if (value != null)
            {
                Double inValue = System.Convert.ToDouble(value);
                GridLength result = new GridLength(inValue, GridUnitType.Pixel);
                return result;
            }

            throw new ValueUnavailableException();
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            // check whether a value is given
            if (value != null)
            {
                GridLength inValue = (GridLength)value;
                return inValue.Value;
            }

            throw new ValueUnavailableException();
        }
    }
}
