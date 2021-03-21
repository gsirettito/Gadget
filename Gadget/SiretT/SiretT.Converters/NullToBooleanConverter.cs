using System;
using System.Globalization;
using System.Windows.Data;

namespace SiretT.Converters {
    public sealed class NullToBooleanConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value == null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is bool ? ((bool)value) ? null : value : Binding.DoNothing;
        }
    }
}
