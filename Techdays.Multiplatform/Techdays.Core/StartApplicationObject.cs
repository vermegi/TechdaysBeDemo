using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.ViewModels;
using Techdays.Core.ViewModels;

namespace Techdays.Core
{
    /// <summary>
    /// Identifies which Viewmodel to start the application with.
    /// </summary>
    public class StartApplicationObject : MvxApplicationObject, IMvxStartNavigation
    {
        public void Start()
        {
            RequestNavigate<HomeViewModel>();
        }

        public bool ApplicationCanOpenBookmarks { get { return false; } }
    }
}