using Cirrious.MvvmCross.WindowsPhone.Views;
using Techdays.Core.ViewModels;

namespace Techdays.WP7.Views
{
    public partial class PracticalInfoView : BasePracticalInfoView
    {
        public PracticalInfoView()
        {
            InitializeComponent();
        }
    }

    public class BasePracticalInfoView : MvxPhonePage<InfoViewModel>
    {
        
    }
}