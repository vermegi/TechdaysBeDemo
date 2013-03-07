using Cirrious.MvvmCross.Converters;

namespace Techdays.Android.Converters
{
    public class SpeakerImageConverter : MvxBaseValueConverter
    {
        public override object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var fullUrl = value.ToString();
            var name = fullUrl.Replace("http://events.feed.comportal.be/techdays/speaker.aspx?name=", "");
            return string.Format("speakers/{0}.png", name.ToLower());
        }
    }
}