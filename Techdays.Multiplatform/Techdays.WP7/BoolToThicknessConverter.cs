using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Techdays.WP7
{
    public class BoolToThicknessConverter : IValueConverter
    {
        private readonly Color _blue;
        private readonly Color _white;

        public BoolToThicknessConverter()
        {
            _blue = Parse("#00BCF2");
            _white = Parse("#FFFFFF");
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var castedToBool = (bool)value;
            if (castedToBool)
                return new SolidColorBrush(_blue);
            return new SolidColorBrush(_white);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        
        private static Color Parse(string color)
        {
            var offset = color.StartsWith("#") ? 1 : 0;

            byte a = 255;
            var r = Byte.Parse(color.Substring(0 + offset, 2), NumberStyles.HexNumber);
            var g = Byte.Parse(color.Substring(2 + offset, 2), NumberStyles.HexNumber);
            var b = Byte.Parse(color.Substring(4 + offset, 2), NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }
    }
}