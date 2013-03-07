using System.Collections.Generic;
using Techdays.Core.Application.Model;
using Techdays.Core.Application.Service;

namespace Techdays.Core.Application.Interfaces
{
    public interface ILoadTopics
    {
        IEnumerable<Topic> GetAll();
    }
}