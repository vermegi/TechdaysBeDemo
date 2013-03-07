using Cirrious.MvvmCross.WindowsPhone.Views;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.WP7.Views
{
    public partial class SessionHomeView : BaseSessionHomeView
    {
        public SessionHomeView()
        {
            InitializeComponent();
        }
    }

    public class BaseSessionHomeView : MvxPhonePage<SessionHomeViewModel>
    {
        
    }
}