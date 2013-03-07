using Cirrious.MvvmCross.ViewModels;

namespace Techdays.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected BaseViewModel()
        {
            AppName = "techdays 2013";
        }

        public string AppName { get; private set; }
    }
}