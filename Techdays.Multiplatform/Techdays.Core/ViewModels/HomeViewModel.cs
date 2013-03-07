using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
		{
            Overview = new OverviewViewModel();
            Topics = new TopicListViewModel();
            UpcomingSessions = new UpcomingSessionsViewModel();
            Tweets = new TweetsViewModel();
		}

        public OverviewViewModel Overview { get; private set; }

        public TopicListViewModel Topics { get; private set; }

        public UpcomingSessionsViewModel UpcomingSessions { get; private set; }

        public TweetsViewModel Tweets { get; private set; }
    }
}