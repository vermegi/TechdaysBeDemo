using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using System.Linq;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;

namespace Techdays.Core.Application.Service
{
    public class SessionLoader : ILoadSessionData, 
        IMvxServiceConsumer<ILoadTechdaysData>
    {
        private IEnumerable<Session> _sessions;

        public IEnumerable<Session> GetSessions()
        {
            if (_sessions == null)
                LoadSessions();

            return _sessions;
        }

        public Session GetSession(int id)
        {
            if (_sessions == null)
                LoadSessions();

            return _sessions.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Session> GetForSpeaker(int speakerId)
        {
            if (_sessions == null)
                LoadSessions();

            return _sessions.Where(s => s.Speakers.Any(sp => sp.Id == speakerId)).ToList();
        }

        private void LoadSessions()
        {
            var techdayLoader = this.GetService<ILoadTechdaysData>();

            var techdaysEvent = techdayLoader.GetEvent();

            var timeslots = (from aday in techdaysEvent.@event.agenda.day
                            select aday.timeslot).SelectMany(t => t);

            var speakers = (from speaker in techdaysEvent.@event.details.speakers.speaker
                            select speaker);

            _sessions = from data in techdaysEvent.@event.details.sessions.sessionextract
                        let theDay = (
                                                 from day in techdaysEvent.@event.agenda.day
                                                 where day.timeslot.Any(t => t.session != null && t.session.Any(s => s.id == data.id))
                                                 select day.date)
                                                 .FirstOrDefault()
                        let thetimeslot = (from slot in timeslots
                                           where slot != null
                                           && slot.session != null
                                           && slot.session.Any(s => s != null && s.id == data.id)
                                           select slot).FirstOrDefault()
                        let thespeakers = (from speaker in speakers
                                           where data.speaker != null && data.speaker.Any(s => s.id == speaker.id)
                                           select speaker)
                        where theDay != null
                        orderby thetimeslot.start
                        select new Session
                                   {
                                       Day = Int32.Parse(theDay.Substring(0, 2)),
                                       StartTime = thetimeslot.start,
                                       EndTime = thetimeslot.end,
                                       Description = data.description,
                                       Id = data.id,
                                       Title = data.title,
                                       Topics = data.tag,
                                       Speaker = thespeakers.FirstOrDefault() != null ? thespeakers.FirstOrDefault().fullname : string.Empty,
                                       SpeakerId = thespeakers.FirstOrDefault() != null ? thespeakers.FirstOrDefault().id : 0,
                                       SpeakerPicture = thespeakers.FirstOrDefault() != null ? thespeakers.FirstOrDefault().picture : string.Empty,
                                       Room = data.room.ToString(),
                                       Speakers = new List<SpeakerBase>(from s in thespeakers
                                                                            select new SpeakerBase(s.id, s.fullname, s.picture))
                                   };
        }
    }
}