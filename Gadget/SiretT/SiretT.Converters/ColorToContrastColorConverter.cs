using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SiretT.Converters {
    public class ColorToContrastColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            Color clr = (Color)value;
            double grayShade = 0.30 * clr.R + 0.59 * clr.G + 0.11 * clr.B;
            return grayShade > 128 ? Colors.Black : Colors.White;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
