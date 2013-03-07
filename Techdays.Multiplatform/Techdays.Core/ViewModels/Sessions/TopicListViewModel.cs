using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Techdays.Core.Application.Interfaces;

namespace Techdays.Core.ViewModels.Sessions
{
    public class TopicListViewModel : BaseViewModel,
                                      IMvxServiceConsumer<ILoadTopics>
    {
        public TopicListViewModel()
        {
            var topicLoader = this.GetService<ILoadTopics>();

            var topicQuery = from topic in topicLoader.GetAll()
                             select new TopicListItem(topic.Name, topic.Count);

            Topics = new ObservableCollection<TopicListItem>(topicQuery);
        }

        public ObservableCollection<TopicListItem> Topics { get; private set; }
    }

    public class TopicListItem : BaseViewModel
    {
        private int _count;
        private string _name;

        public TopicListItem(string name, int count)
        {
            Count = count;
            Name = name;
        }

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                RaisePropertyChanged("Count");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public ICommand ShowSessionsForTopic
        {
            get
            {
                return
                    new MvxRelayCommand(
                        () => RequestNavigate<SessionHomeViewModel>(new Dictionary<string, object> {{"track", Name}}));
            }
        }
    }
}