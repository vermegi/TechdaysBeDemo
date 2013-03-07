using Techdays.Core.ViewModels.Sessions;
using Techdays.WinRT.Common;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Techdays.WinRT.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FullProgramView : LayoutAwarePage
    {
        public FullProgramView()
        {
            this.InitializeComponent();
        }

        public new SessionHomeViewModel ViewModel
        {
            get { return (SessionHomeViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
