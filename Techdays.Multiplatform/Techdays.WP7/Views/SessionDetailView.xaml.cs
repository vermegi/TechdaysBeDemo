using Cirrious.MvvmCross.WindowsPhone.Views;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.WP7.Views
{
    public partial class SessionDetailView : BaseSessionDetail
    {
        public SessionDetailView()
        {
            InitializeComponent();
        }
    }

    public class BaseSessionDetail : MvxPhonePage<SessionDetailViewModel>
    {
        
    }
}