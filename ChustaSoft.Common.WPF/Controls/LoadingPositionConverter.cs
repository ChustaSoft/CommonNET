using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ChustaSoft.Common.Controls
{
    public class LoadingPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = (LoadingPosition)value;

            switch (enumValue)
            {
                case LoadingPosition.Bottom:
                    return VerticalAlignment.Bottom;
                case LoadingPosition.Top:
                    return VerticalAlignment.Top;

                default:
                    return VerticalAlignment.Center;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
