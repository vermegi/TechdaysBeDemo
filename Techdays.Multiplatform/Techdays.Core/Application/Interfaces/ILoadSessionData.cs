using System.Collections.Generic;
using Techdays.Core.Application.Model;

namespace Techdays.Core.Application.Interfaces
{
    public interface ILoadSessionData
    {
        IEnumerable<Session> GetSessions();
        Session GetSession(int id);
        IEnumerable<Session> GetForSpeaker(int speakerId);
    }
}