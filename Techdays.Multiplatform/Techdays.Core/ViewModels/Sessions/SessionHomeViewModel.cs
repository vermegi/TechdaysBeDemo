using System.Collections.ObjectModel;

namespace Techdays.Core.ViewModels.Sessions
{
    public class SessionHomeViewModel : BaseViewModel
    {
        public SessionHomeViewModel(string track)
        {
            Days = new ObservableCollection<SessionListViewModel>();
            Days.Add(new SessionListViewModel(5, track));
            Days.Add(new SessionListViewModel(6, track));
            Days.Add(new SessionListViewModel(7, track));
        }

        public ObservableCollection<SessionListViewModel> Days { get; set; }
    }
}