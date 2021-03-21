using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SiretT.Converters {
    public sealed class CompareToVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value.ToString() == parameter.ToString()) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
}
