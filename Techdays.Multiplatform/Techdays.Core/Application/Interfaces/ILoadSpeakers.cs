using System.Collections.Generic;
using Techdays.Core.Application.Model;

namespace Techdays.Core.Application.Interfaces
{
    public interface ILoadSpeakers
    {
        IEnumerable<Speaker> GetAll();
        Speaker GetById(int id);
    }
}