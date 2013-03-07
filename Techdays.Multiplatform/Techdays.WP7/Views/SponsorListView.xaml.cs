using Cirrious.MvvmCross.WindowsPhone.Views;
using Techdays.Core.ViewModels;

namespace Techdays.WP7.Views
{
    public partial class SponsorListView : BaseSponsorListView
    {
        public SponsorListView()
        {
            InitializeComponent();
        }
    }

    public class BaseSponsorListView : MvxPhonePage<SponsorListViewModel>
    {
        
    }
}