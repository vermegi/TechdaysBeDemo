using Cirrious.MvvmCross.WinRT.Views;
using Techdays.Core.ViewModels;
using Techdays.WinRT.Common;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Techdays.WinRT.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : LayoutAwarePage
    {
        public HomeView()
        {
            this.InitializeComponent();
        }

        public new HomeViewModel ViewModel
        {
            get { return (HomeViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
