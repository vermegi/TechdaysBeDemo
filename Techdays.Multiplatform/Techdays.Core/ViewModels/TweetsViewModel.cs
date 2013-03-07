using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;

namespace Techdays.Core.ViewModels
{
    public class TweetsViewModel : BaseViewModel,
        IMvxServiceConsumer<ILoadTweets>
    {
        private ObservableCollection<Tweet> _tweets;
        private readonly ILoadTweets _loader;
        private bool _isLoading;

        public TweetsViewModel()
        {
            _loader = this.GetService<ILoadTweets>();

            LoadTweets();
        }

        private void LoadTweets()
        {
            IsLoading = true;
            _loader.GetTweetsAsync(Success, Error);
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
        }

        private void Success(IEnumerable<Tweet> tweets)
        {
            InvokeOnMainThread(() =>
                                   {
                                       IsLoading = false;
                                       Tweets = new ObservableCollection<Tweet>(tweets.ToList());
                                   });
        }

        public ObservableCollection<Tweet> Tweets
        {
            get { return _tweets; }
            set { _tweets = value; RaisePropertyChanged(() => Tweets); }
        }

        private void Error(Exception exc)
        {
            InvokeOnMainThread(() =>
                                   {
                                       IsLoading = false;
                                       ErrorMessage = string.Format("Sorry, there was a problem getting the tweets. {0}", exc.Message);
                                   });
        }

        public string ErrorMessage { get; set; }

        public ICommand RefreshTweets
        {
            get { return new MvxRelayCommand(LoadTweets); }
        }
    }
}