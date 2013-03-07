namespace Techdays.Android.Converters
{
    public class MyConverters
    {
        public readonly SpeakerImageConverter SpeakerImage = new SpeakerImageConverter();
        public readonly LinkImageConverter LinkImage = new LinkImageConverter();
        public readonly BoolToColorConverter BoolToColor = new BoolToColorConverter();
    }
}