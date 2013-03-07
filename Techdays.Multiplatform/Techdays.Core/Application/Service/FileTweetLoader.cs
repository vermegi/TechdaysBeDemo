using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Cirrious.MvvmCross.Core;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Plugins.ResourceLoader;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.ViewModels;
using Techdays.Core.ViewModels.Util;

namespace Techdays.Core.Application.Service
{
    public class FileTweetLoader : ILoadTweets,
        IMvxServiceConsumer<IMvxResourceLoader>
    {
        private Action<IEnumerable<Tweet>> _success;
        private Action<Exception> _error;

        public void GetTweetsAsync(Action<IEnumerable<Tweet>> success, Action<Exception> error)
        {
            _success = success;
            _error = error;

            MvxAsyncDispatcher.BeginAsync(DoAsyncSearch);
        }

        private void DoAsyncSearch()
        {
            try
            {
                // perform the search
                var loader = this.GetService<IMvxResourceLoader>();
                var tweetXml = loader.GetTextResource("tweets.xml");
                HandleResponse(tweetXml);
            }
            catch (Exception exception)
            {
                _error(exception);
            }
        }

        private void HandleResponse(string resultString)
        {
            var doc = XDocument.Parse(resultString);
            var items = doc.Descendants(AtomConst.Entry)
                           .Select(entryElement => new Tweet
                                                       {
                                                           Title = entryElement.Descendants(AtomConst.Title).Single().Value,
                                                           Id = long.Parse(entryElement.Descendants(AtomConst.ID).Single().Value.Split(':')[2]),
                                                           ProfileImageUrl = entryElement.Descendants(AtomConst.Link).Skip(1).First().Attribute("href").Value,
                                                           Timestamp = DateTime.Parse(entryElement.Descendants(AtomConst.Published).Single().Value),
                                                           Author = entryElement.Descendants(AtomConst.Name).Single().Value
                                                       });
            _success(items);
        }
    }
}