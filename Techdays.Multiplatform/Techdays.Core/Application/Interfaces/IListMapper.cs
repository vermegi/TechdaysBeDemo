using System.Collections.Generic;

namespace Techdays.Core.Application.Interfaces
{
    public interface IListMapper<TFrom, TTo>
    {
        IEnumerable<TTo> Map(IEnumerable<TFrom> from);
    }
}