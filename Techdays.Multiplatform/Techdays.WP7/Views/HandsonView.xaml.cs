using Cirrious.MvvmCross.WindowsPhone.Views;
using Techdays.Core.ViewModels;

namespace Techdays.WP7.Views
{
    public partial class HandsonView : BaseHandsonView
    {
        public HandsonView()
        {
            InitializeComponent();
        }
    }

    public class BaseHandsonView : MvxPhonePage<HandsonViewModel>
    {
        
    }
}