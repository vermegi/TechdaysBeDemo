using Cirrious.MvvmCross.Converters;
using Cirrious.MvvmCross.Plugins.Color;
using Cirrious.MvvmCross.Plugins.Color.Droid;

namespace Techdays.Android.Converters
{
    public class BoolToColorConverter : MvxBaseValueConverter
    {
        public override object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var thevalue = (bool) value;
            var color = new MvxAndroidColor();
            return thevalue ? color.ToAndroidColor(new MvxColor(255, 153, 0)) : color.ToAndroidColor(new MvxColor(255, 255, 255));
        }
    }
}