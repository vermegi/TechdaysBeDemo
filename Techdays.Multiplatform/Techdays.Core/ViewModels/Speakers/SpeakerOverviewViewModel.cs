using System.Collections.ObjectModel;
using System.Linq;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Sessions;
using Techdays.Core.ViewModels.Util;

namespace Techdays.Core.ViewModels.Speakers
{
    public class SpeakerOverviewViewModel : BaseViewModel,
        IMvxServiceConsumer<ILoadSpeakers>,
        IMvxServiceConsumer<IMapInPlace<Speaker, SpeakerOverviewViewModel>>,
        IMvxServiceConsumer<ILoadSessionData>,
        IMvxServiceConsumer<IListMapper<Session, SessionListItemViewModel>>
    {
        public SpeakerOverviewViewModel(int id)
        {
            var speakerLoader = this.GetService<ILoadSpeakers>();
            var mapper = this.GetService<IMapInPlace<Speaker, SpeakerOverviewViewModel>>();
            var sessionLoader = this.GetService<ILoadSessionData>();
            var sessionMapper = this.GetService<IListMapper<Session, SessionListItemViewModel>>();

            var speaker = speakerLoader.GetById(id);
            mapper.Map(speaker, this);

            var sessions = sessionLoader.GetForSpeaker(id);
            var mappedSessions = sessionMapper.Map(sessions).OrderBy(ses => ses.Day);
            var group = mappedSessions.GroupBy(session => session.Day)
                                        .Select(timeslot => new TimeGroup<SessionListItemViewModel>(
                                                   new ObservableCollection<SessionListItemViewModel>(timeslot), string.Format("{0} March", timeslot.First().Day)));
            
            Sessions = new SpeakerSessionsViewModel
                           {
                               Sessions = new ObservableCollection<TimeGroup<SessionListItemViewModel>>(group)
                           };
        }

        public SpeakerDetailViewModel Speaker { get; set; }
        public SpeakerSessionsViewModel Sessions { get; set; }
    }
}