using System.Collections.Generic;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.Application.Model;

namespace Techdays.Core.Application.Service.Dummies
{
    public class DummyTopicLoader : ILoadTopics
    {
        public IEnumerable<Topic> GetAll()
        {
            var topics = new List<Topic>();

            for (char c = 'A'; c < 'L'; c++ )
                topics.Add(new Topic
                               {
                                   Name = c.ToString(),
                                   Count = 5
                               });

            return topics;
        }
    }
}