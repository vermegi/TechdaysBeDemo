using Cirrious.MvvmCross.WindowsPhone.Views;
using Techdays.Core.ViewModels;

namespace Techdays.WP8.Views
{
    public partial class HomeView : BaseHomeView
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }

    public class BaseHomeView : MvxPhonePage<HomeViewModel>
    {
    }
}