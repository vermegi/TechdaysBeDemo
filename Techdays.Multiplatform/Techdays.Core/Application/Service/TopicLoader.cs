using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;

namespace Techdays.Core.Application.Service
{
    public class TopicLoader : ILoadTopics,
        IMvxServiceConsumer<ILoadTechdaysData>
    {
        private IEnumerable<Topic> _topics;

        public IEnumerable<Topic> GetAll()
        {
            if (_topics == null)
                LoadTopics();

            return _topics;
        }

        private void LoadTopics()
        {
            var loader = this.GetService<ILoadTechdaysData>();

            var techdaysEvent = loader.GetEvent();

            _topics = from topic in
                          (from session in techdaysEvent.@event.details.sessions.sessionextract
                           where session != null && session.tag != null
                           select session.tag).SelectMany(t => t)
                      group topic by topic
                      into g
                      orderby g.Key
                      select new Topic
                                 {
                                     Name = g.Key,
                                     Count = g.Count()
                                 };
        }
    }
}