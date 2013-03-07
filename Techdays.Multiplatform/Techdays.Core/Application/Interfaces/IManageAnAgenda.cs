using System;

namespace Techdays.Core.Application.Interfaces
{
    public interface IManageAnAgenda
    {
        void Add(int sessionId);
        bool IsInAgenda(int sessionId);
        event EventHandler SessionAdded;
    }
}