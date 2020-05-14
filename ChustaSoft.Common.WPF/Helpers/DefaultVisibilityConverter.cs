using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ChustaSoft.Common.Helpers
{
    /// <summary>
    /// Gives visibility by default when nothing is retrived
    /// </summary>
    public class DefaultVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
