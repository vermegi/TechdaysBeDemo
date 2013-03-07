using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.Core.Application.Mappers
{
    public class SessionOverviewMapping : IListMapper<Session, SessionListItemViewModel>,
        IMvxServiceConsumer<IManageAnAgenda>
    {
        public IEnumerable<SessionListItemViewModel> Map(IEnumerable<Session> sessions)
        {
            var mappedSessions = (from session in sessions
                                 select new SessionListItemViewModel
                                 {
                                     Day = session.Day,
                                     EndTime = session.EndTime,
                                     StartTime = session.StartTime,
                                     Speaker = session.Speaker,
                                     Speakers = from s in session.Speakers
                                                select s.Fullname,
                                     Title = session.Title,
                                     SessionId = session.Id,
                                     Topic = session.Topics != null ? string.Join(", ", session.Topics) : string.Empty,
                                     Track = session.Track,
                                     Room = string.Format("room {0}", session.Room),
                                 }).ToList();

            var agendaService = this.GetService<IManageAnAgenda>();
            foreach (var session in mappedSessions)
            {
                session.InAgenda = agendaService.IsInAgenda(session.SessionId);
            }

            return mappedSessions;            
        }
    }
}