using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Util;

namespace Techdays.Core.ViewModels.Sessions
{
    public class SessionListViewModel : BaseViewModel, 
        IMvxServiceConsumer<ILoadSessionData>, 
        IMvxServiceConsumer<IListMapper<Session, SessionListItemViewModel>>
    {
        private readonly int _day;
        private readonly string _track;
        private readonly IEnumerable<SessionListItemViewModel> _allSessions;

        public SessionListViewModel(int day, string track)
        {
            _day = day;
            _track = track;

            var service = this.GetService<ILoadSessionData>();
            var sessions = service.GetSessions();

            var mapper = this.GetService<IListMapper<Session, SessionListItemViewModel>>();
            _allSessions = mapper.Map(sessions);

            var slots = ToGroup(SessionsFilteredByDayAndTrack);

            TimeSlots = new ObservableCollection<TimeGroup<SessionListItemViewModel>>(slots);

            Day = string.Format("day {0} - {1} March", _day - 4, _day);
        }

        public string TheText { get { return string.Format("This is the session vm with day {0} for {1}", _day, _track); } }

        public string Day { get; private set; }

        public ObservableCollection<TimeGroup<SessionListItemViewModel>> TimeSlots { get; set; }

        public void FilterSessions(string selectedTopic)
        {
            var filtered = ToGroup(SessionsFilteredByDayAndTrack.Where(session => session.Topic.Contains(selectedTopic)));

            TimeSlots = new ObservableCollection<TimeGroup<SessionListItemViewModel>>(filtered);
            
            RaisePropertyChanged(() => TimeSlots);
        }

        private IEnumerable<SessionListItemViewModel> SessionsFilteredByDayAndTrack
        {
            get
            {
                if (_track == string.Empty)
                    return _allSessions.Where(session => session.Day == _day);
                return _allSessions.Where(session => session.Day == _day 
                                                        && session.Topic != null 
                                                        && session.Topic.Contains(_track));
            }
        }

        private IEnumerable<TimeGroup<SessionListItemViewModel>> ToGroup(IEnumerable<SessionListItemViewModel> sessions)
        {
            return sessions.GroupBy(session => session.StartTime)
                           .Select(timeslot => new TimeGroup<SessionListItemViewModel>(
                                                   new ObservableCollection<SessionListItemViewModel>(timeslot),
                                                                 timeslot.First().StartTime.ToString("H:mm"),
                                                                 timeslot.First().EndTime.ToString("H:mm")));
        }
    }
}