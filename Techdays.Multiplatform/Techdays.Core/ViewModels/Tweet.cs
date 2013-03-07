using System;

namespace Techdays.Core.ViewModels
{
    public class Tweet
    {
        public string Title { get; set; }

        public long Id { get; set; }

        public string ProfileImageUrl { get; set; }

        public DateTime Timestamp { get; set; }

        public string Author { get; set; }
    }
}