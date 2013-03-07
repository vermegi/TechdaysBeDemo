using System;
using System.Collections.Generic;
using Techdays.Core.ViewModels;

namespace Techdays.Core.Application.Interfaces
{
    public interface ILoadTweets
    {
        void GetTweetsAsync(Action<IEnumerable<Tweet>> success, Action<Exception> error);
    }
}