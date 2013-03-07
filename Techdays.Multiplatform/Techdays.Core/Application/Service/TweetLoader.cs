using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Cirrious.MvvmCross.Core;
using Techdays.Core.Application.Interfaces;
using Techdays.Core.ViewModels;
using Techdays.Core.ViewModels.Util;

namespace Techdays.Core.Application.Service
{
    public class TweetLoader : ILoadTweets
    {
        private Action<IEnumerable<Tweet>> _success;
        private Action<Exception> _error;
        private const string TwitterUrl = "http://search.twitter.com/search.atom?rpp=30&&q=";

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
                const string uri = TwitterUrl + "techdaysbe";
                var request = WebRequest.Create(new Uri(uri));
                request.BeginGetResponse(ReadCallback, request);
            }
            catch (Exception exception)
            {
                _error(exception);
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                var request = (HttpWebRequest)ar.AsyncState;
                var response = (HttpWebResponse)request.EndGetResponse(ar);
                using (var streamReader1 = new StreamReader(response.GetResponseStream()))
                {
                    string resultString = streamReader1.ReadToEnd();
                    HandleResponse(resultString);
                }
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