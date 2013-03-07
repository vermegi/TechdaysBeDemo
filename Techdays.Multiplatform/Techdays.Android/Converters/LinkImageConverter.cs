using Cirrious.MvvmCross.Converters;

namespace Techdays.Android.Converters
{
    public class LinkImageConverter : MvxBaseValueConverter
    {
        public override object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Format("pics/{0}.png", value.ToString().ToLower());
        }
    }
}