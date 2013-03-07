using Cirrious.MvvmCross.Platform.Diagnostics;

namespace Techdays.Core
{
    public static class TechdaysTrace
    {
        public const string Tag = "TechDaysApp";

        public static void Trace(string message, params object[] args)
        {
            MvxTrace.TaggedTrace(Tag, message, args);
        }
    }
}