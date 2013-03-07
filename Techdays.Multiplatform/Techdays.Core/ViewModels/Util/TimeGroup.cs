using System.Collections.Generic;

namespace Techdays.Core.ViewModels.Util
{
    public class TimeGroup<T> : List<T>
    {
        private string _title;

        public TimeGroup(IEnumerable<T> items, string startTime, string endTime) : base(items)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public TimeGroup(IEnumerable<T> items, string title) : base(items)
        {
            Title = title;
        }


        public string StartTime { get; set; }
        
        public string EndTime { get; set; }

        public string Title
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_title))
                    return _title;

                return string.Format("{0} - to - {1}", StartTime, EndTime);
            }
            set { _title = value; }
        }
    }
}