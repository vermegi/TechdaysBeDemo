using System;
using System.Collections.Generic;
using System.Linq;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;

namespace Techdays.Core.Application.Service.Dummies
{
    public class DummySessionLoader : ILoadSessionData
    {
        private List<Session> _sessions;

        private void InitSessions()
        {
            _sessions = new List<Session>
                       {
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("9:00"),
                                   EndTime = DateTime.Parse("10:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"Coding"}
                               },
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("9:00"),
                                   EndTime = DateTime.Parse("10:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"ALM"}
                               },
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("9:00"),
                                   EndTime = DateTime.Parse("10:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"Coding"}
                               },
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("10:00"),
                                   EndTime = DateTime.Parse("11:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"Coding"}
                               },
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("10:00"),
                                   EndTime = DateTime.Parse("11:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"ALM"}
                               },
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("10:00"),
                                   EndTime = DateTime.Parse("11:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"Development"}
                               },
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("10:00"),
                                   EndTime = DateTime.Parse("11:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"ALM"}
                               },                           
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("11:00"),
                                   EndTime = DateTime.Parse("12:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"ALM"}
                               },
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("11:00"),
                                   EndTime = DateTime.Parse("12:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"ALM"}
                               },
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("11:00"),
                                   EndTime = DateTime.Parse("12:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"ALM"}
                               },
                           new Session
                               {
                                   Day = 5,
                                   StartTime = DateTime.Parse("11:00"),
                                   EndTime = DateTime.Parse("12:00"),
                                   Speaker = "Joske Vermeulen",
                                   Title = "How to get your app in here",
                                   Topics = new List<string>{"Development"}
                               },
                       };

            int i = 0;
            foreach (var session in _sessions)
            {
                session.Id = ++i;
                session.Track = i % 2 == 0 ? "dev" : "itpro";
                session.Room = string.Format("Room {0}", i % 3);
                session.SpeakerId = i%7;
                session.Day = 5 + (i%2);
            }            
        }

        public IEnumerable<Session> GetSessions()
        {
            if (_sessions == null)
                InitSessions();
            return _sessions;
        }

        public Session GetSession(int id)
        {
            return new Session
                       {
                           Day = 5,
                           StartTime = DateTime.Parse("10:00"),
                           EndTime = DateTime.Parse("11:00"),
                           Title = "Doe de lange sessietitel die niet op één lijn past tralalalala",
                           Speaker = "Mie Off Course",
                           SpeakerId = 5,
                           Topics = new List<string>{"Mobile"},
                           Room = "Room 3",
                           Id = 2,
                           Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.",
                           SpeakerPicture = "http://events.feed.comportal.be/techdays/speaker.aspx?name=GitteVermeiren"
                       };
        }

        public IEnumerable<Session> GetForSpeaker(int speakerId)
        {
            if (_sessions == null)
                InitSessions();

            return from session in _sessions
                    where session.SpeakerId == speakerId
                    select session;
        }
    }
}