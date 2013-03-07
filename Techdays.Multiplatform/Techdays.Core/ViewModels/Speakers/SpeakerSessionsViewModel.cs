using System.Collections.ObjectModel;
using Techdays.Core.ViewModels.Sessions;
using Techdays.Core.ViewModels.Util;

namespace Techdays.Core.ViewModels.Speakers
{
    public class SpeakerSessionsViewModel : BaseViewModel
    {
        public ObservableCollection<TimeGroup<SessionListItemViewModel>> Sessions { get; set; } 
    }
}